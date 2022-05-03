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
    public class EmployeeViewModel : TableParentViewModel<EmployeeViewModel, EmployeeRelatedTablesResponse, EmployeeResponse, Employee>,
        IDeletable, IUpdatable<Employee>, IDialogRequestClose
    {
        public Employee Model { get; set; }

        public bool IsChecked { get; set; }
        public Guid Id => Model.Id;

        public bool IsUpdated { get; set; } = false;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;
        public ICommand EmployeeUpdateShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Mapper _mapper;
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public EmployeeViewModel(IEmployeesProvider provider, IDialogService dialogService, Mapper mapper) : base(provider)
        {
            this._mapper = mapper;
            EmployeeUpdateShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public async void ResultHandler(IDialogService dialogService)
        {
            var response = await ReadRelatedTables();
            Departments = _mapper.Map<IEnumerable<Department>>(response.Departments);
            Positions = _mapper.Map<IEnumerable<Position>>(response.Positions);

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
