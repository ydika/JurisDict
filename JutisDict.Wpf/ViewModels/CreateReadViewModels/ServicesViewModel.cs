using AutoMapper;
using Common.DTOs;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels;
using Common.Exceptions;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.Dialogs.Interfaces;
using Common.Defaults;
using JurisDict.Wpf.Dialogs;
using JurisDict.Wpf.ViewModels.UpdateDeleteViewModels;

namespace JurisDict.Wpf.ViewModels.CreateReadViewModels
{
    public class ServicesViewModel : TableBaseViewModel<ServiceViewModel, Service, ServiceResponse>, IDialogRequestClose
    {
        private readonly IDialogService _dialogService;
        public ICommand ServiceCreationShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public Service Service { get; set; }

        public ServicesViewModel(IServicesProvider provider, Mapper mapper, DeleteCommandProxy deleteCommandProxy, 
            UpdateCommandProxy updateCommandProxy, IDialogService dialogService)
            : base(provider, mapper, deleteCommandProxy, updateCommandProxy)
        {
            this._dialogService = dialogService;
            ServiceCreationShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;

        protected override ServiceViewModel CreateViewModel(Service model)
        {
            return new ServiceViewModel(_dialogService)
            {
                Model = model
            };
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            Service = new DefaultModels().Service;
            var result = dialogService.ShowDialog(this);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    await CreateViewModels(Service);
                }
                else
                {
                }
            }
        }
    }
}
