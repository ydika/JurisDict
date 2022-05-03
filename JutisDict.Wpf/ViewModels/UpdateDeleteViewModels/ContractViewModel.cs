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
    public class ContractViewModel : TableParentViewModel<ContractViewModel, ContractRelatedTablesResponse, ContractResponse, Contract>, 
        IDeletable, IUpdatable<Contract>, IDialogRequestClose
    {
        public Contract Model { get; set; }

        public bool IsChecked { get; set; }
        public Guid Id => Model.Id;

        public bool IsUpdated { get; set; } = false;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;
        public ICommand ContractUpdateShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Mapper _mapper;
        public IEnumerable<Client> Clients { get; set; }

        public ContractViewModel(IContractsProvider provider, IDialogService dialogService, Mapper mapper) : base(provider)
        {
            this._mapper = mapper;
            ContractUpdateShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }
        
        public async void ResultHandler(IDialogService dialogService)
        {
            var response = await ReadRelatedTables();
            Clients = _mapper.Map<IEnumerable<Client>>(response.Clients);

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
