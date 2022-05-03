using AutoMapper;
using Common.Exceptions;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JurisDict.Wpf.ViewModels
{
    public class TableParentViewModel<TViewModel, TRelatedTablesResponse, TResponse, TModel> : 
        TableBaseViewModel<TViewModel, TModel, TResponse> where TViewModel : ObservableObject, IDeletable, IUpdatable<TModel>
    {
        protected new IProvider<TRelatedTablesResponse, TResponse, TModel> Provider { get; }

        public TableParentViewModel(IProvider<TRelatedTablesResponse, TResponse, TModel> provider)
        {
            Provider = provider;
        }

        public TableParentViewModel(IProvider<TRelatedTablesResponse, TResponse, TModel> provider, Mapper mapper, DeleteCommandProxy deleteCommandProxy, UpdateCommandProxy updateCommandProxy) 
            : base(provider, mapper, deleteCommandProxy, updateCommandProxy)
        {
            Provider = provider;
        }

        public async Task<TRelatedTablesResponse> ReadRelatedTables()
        {
            try
            {
                return await Provider.ReadRelatedTables();
            }
            catch (HttpException e)
            {
                MessageBox.Show($"Статус код: {e.StatusCode}\n" +
                                $"Ошибка: {e.Message}\n" +
                                $"Url: {e.Url}.\n" +
                                $"Stack trace: {e.StackTrace}");
            }
            return default;
        }

        protected override TViewModel CreateViewModel(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
