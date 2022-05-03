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
    public class EmployeesViewModel : TableParentViewModel<EmployeeViewModel, EmployeeRelatedTablesResponse, EmployeeResponse, Employee>, 
        IDialogRequestClose
    {
        private readonly IDialogService _dialogService;
        public ICommand EmployeeCreationShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public Employee Employee { get; set; }


        protected new IEmployeesProvider Provider { get; }
        private readonly Mapper _mapper;
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public EmployeesViewModel(IEmployeesProvider provider, Mapper mapper, DeleteCommandProxy deleteCommandProxy, 
            UpdateCommandProxy updateCommandProxy, IDialogService dialogService)
            : base(provider, mapper, deleteCommandProxy, updateCommandProxy)
        {
            this.Provider = provider;
            this._mapper = mapper;
            this._dialogService = dialogService;
            EmployeeCreationShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;

        protected override EmployeeViewModel CreateViewModel(Employee model)
        {
            return new EmployeeViewModel(Provider, _dialogService, _mapper)
            {
                Model = model
            };
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            Employee = new DefaultModels().Employee;

            var response = await ReadRelatedTables();
            Departments = _mapper.Map<IEnumerable<Department>>(response.Departments);
            Positions = _mapper.Map<IEnumerable<Position>>(response.Positions);

            var result = dialogService.ShowDialog(this);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    await CreateViewModels(Employee);
                }
                else
                {
                }
            }
        }
    }
}
