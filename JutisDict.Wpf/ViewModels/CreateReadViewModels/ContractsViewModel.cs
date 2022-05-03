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
using Common.DTOs.Responses.CreateUpdateResponses;

namespace JurisDict.Wpf.ViewModels.CreateReadViewModels
{
    public class ContractsViewModel : TableParentViewModel<ContractViewModel, ContractRelatedTablesResponse, ContractResponse, Contract>, 
        IDialogRequestClose
    {
        private readonly IDialogService _dialogService;
        public ICommand ContractCreationShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public Contract Contract { get; set; }

        protected new IContractsProvider Provider { get; }
        private readonly Mapper _mapper;
        public IEnumerable<Client> Clients { get; set; }

        public ContractsViewModel(IContractsProvider provider, Mapper mapper, DeleteCommandProxy deleteCommandProxy, 
            UpdateCommandProxy updateCommandProxy, IDialogService dialogService)
            : base(provider, mapper, deleteCommandProxy, updateCommandProxy)
        {
            this.Provider = provider;
            this._mapper = mapper;
            this._dialogService = dialogService;
            ContractCreationShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;

        protected override ContractViewModel CreateViewModel(Contract model)
        {
            return new ContractViewModel(Provider, _dialogService, _mapper)
            {
                Model = model
            };
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            Contract = new DefaultModels().Contract;

            var response = await ReadRelatedTables();
            Clients = _mapper.Map<IEnumerable<Client>>(response.Clients);

            var result = dialogService.ShowDialog(this);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    await CreateViewModels(Contract);
                }
                else
                {
                }
            }
        }
    }
}
