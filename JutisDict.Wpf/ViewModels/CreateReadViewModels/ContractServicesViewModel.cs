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
using System.Windows;
using Common.Exceptions;
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
    public class ContractServicesViewModel : TableParentViewModel<ContractServiceViewModel, ContractServiceRelatedTablesResponse, ContractServiceResponse, ContractService>,
        IDialogRequestClose
    {
        private readonly IDialogService _dialogService;
        public ICommand ContractServiceCreationShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public ContractService ContractService { get; set; }

        protected new IContractServicesProvider Provider { get; }
        private readonly Mapper _mapper;
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public ContractServicesViewModel(IContractServicesProvider provider, Mapper mapper, DeleteCommandProxy deleteCommandProxy, 
            UpdateCommandProxy updateCommandProxy, IDialogService dialogService)
            : base(provider, mapper, deleteCommandProxy, updateCommandProxy)
        {
            this.Provider = provider;
            this._mapper = mapper;
            this._dialogService = dialogService;
            ContractServiceCreationShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;

        protected override ContractServiceViewModel CreateViewModel(ContractService model)
        {
            return new ContractServiceViewModel(Provider, _dialogService, _mapper)
            {
                Model = model
            };
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            ContractService = new DefaultModels().ContractService;

            var response = await ReadRelatedTables();
            Contracts = _mapper.Map<IEnumerable<Contract>>(response.Contracts);
            Services = _mapper.Map<IEnumerable<Service>>(response.Services);
            Employees = _mapper.Map<IEnumerable<Employee>>(response.Employees);

            var result = dialogService.ShowDialog(this);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    await CreateViewModels(ContractService);
                }
                else
                {
                }
            }
        }
    }
}
