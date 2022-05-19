using AutoMapper;
using Common.Exceptions;
using Common.Models;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JurisDict.Wpf.ViewModels
{
    public abstract class TableBaseViewModel<TViewModel, TModel, TResponse> : ObservableObject, IAsyncLoadable where TViewModel : ObservableObject, IDeletable, IUpdatable<TModel>
    {
        public ObservableCollection<TViewModel> ViewModelsCollection { get; set; }

        protected ICrudProvider<TResponse, TModel> Provider { get; }
        private readonly Mapper _mapper;

        protected abstract TViewModel CreateViewModel(TModel model);
        public async Task CreateViewModels(TModel model)
        {
            try
            {
                var responseMessage = _mapper.Map<TModel>(await Provider.Create(model));

                ViewModelsCollection.Add(CreateViewModel(responseMessage));
            }
            catch (HttpException e)
            {
                MessageBox.Show($"Статус код: {e.StatusCode}\n" +
                                $"Ошибка: {e.Message}\n" +
                                $"Url: {e.Url}.\n" +
                                $"Stack trace: {e.StackTrace}");
            }
        }

        public async Task ReadViewModels()
        {
            try
            {
                var responseMessage = await Provider.Read();

                var models = _mapper.Map<IEnumerable<TModel>>(responseMessage);
                var viewModels = models.Select(x => CreateViewModel(x));

                ViewModelsCollection = new ObservableCollection<TViewModel>(viewModels);
            }
            catch (HttpException e)
            {
                MessageBox.Show($"Статус код: {e.StatusCode}\n" +
                                $"Ошибка: {e.Message}\n" +
                                $"Url: {e.Url}.\n" +
                                $"Stack trace: {e.StackTrace}");
            }
        }

        public async Task UpdateViewModels()
        {
            try
            {
                var updatedModels = ViewModelsCollection.Where(x => x.IsUpdated is true);
                var models = updatedModels.Select(x => x.Model);
                var responseMessage = await Provider.Update(models);
                if (responseMessage is not null)
                {
                    foreach (var updatedModel in updatedModels)
                    {
                        updatedModel.IsUpdated = false;
                    }
                }
            }
            catch (HttpException e)
            {
                MessageBox.Show($"Статус код: {e.StatusCode}\n" +
                                $"Ошибка: {e.Message}\n" +
                                $"Url: {e.Url}.\n" +
                                $"Stack trace: {e.StackTrace}");
            }
        }

        public async Task DeleteViewModels()
        {
            try
            {
                var guids = ViewModelsCollection.Where(x => x.IsDelete is true).Select(x => x.Id);
                var responseMessage = await Provider.Delete(guids);

                var viewModels = ViewModelsCollection.Where(x => responseMessage.Contains(x.Id)).ToList();
                foreach (var viewModel in viewModels)
                {
                    ViewModelsCollection.Remove(viewModel);
                }
            }
            catch (HttpException e)
            {
                MessageBox.Show($"Статус код: {e.StatusCode}\n" +
                                $"Ошибка: {e.Message}\n" +
                                $"Url: {e.Url}.\n" +
                                $"Stack trace: {e.StackTrace}");
            }
        }

        public TableBaseViewModel()
        {
        }

        public TableBaseViewModel(ICrudProvider<TResponse, TModel> provider, Mapper mapper, 
            DeleteCommandProxy deleteCommandProxy, UpdateCommandProxy updateCommandProxy)
        {
            this.Provider = provider;
            this._mapper = mapper;
            deleteCommandProxy.OnDelete += DeleteCommandProxy_OnDelete;
            updateCommandProxy.OnUpdate += UpdateCommandProxy_OnUpdate;
        }

        public async Task LoadAsync()
        {
            await ReadViewModels();
        }

        private async void DeleteCommandProxy_OnDelete()
        {
            await DeleteViewModels();
        }

        private async void UpdateCommandProxy_OnUpdate()
        {
            await UpdateViewModels();
        }
    }
}
