using AutoMapper;
using Common.Models;
using JurisDict.Wpf.Dialogs;
using JurisDict.Wpf.Dialogs.Interfaces;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels.Interfaces;
using JurisDict.Wpf.Views.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JurisDict.Wpf.ViewModels.UpdateDeleteViewModels
{
    public class ContractServiceViewModel : TableParentViewModel<ContractServiceViewModel, ContractServiceRelatedTablesResponse, ContractServiceResponse, ContractService>,
        IDeletable, IUpdatable<ContractService>, IDialogRequestClose
    {
        public ContractService Model { get; set; }

        public bool IsChecked { get; set; }
        public Guid Id => Model.Id;

        public bool IsUpdated { get; set; } = false;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;
        public ICommand ContractServiceUpdateShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Mapper _mapper;
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public ContractServiceViewModel(IContractServicesProvider provider, IDialogService dialogService, Mapper mapper) : base(provider)
        {
            this._mapper = mapper;
            ContractServiceUpdateShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            var response = await ReadRelatedTables();
            Contracts = _mapper.Map<IEnumerable<Contract>>(response.Contracts);
            Services = _mapper.Map<IEnumerable<Service>>(response.Services);
            Employees = _mapper.Map<IEnumerable<Employee>>(response.Employees);

            var result = dialogService.ShowDialog(this);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    IsUpdated = true;
                }
                else
                {
                }
            }
        }
    }
}
