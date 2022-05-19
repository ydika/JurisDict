using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using JurisDict.Wpf.Icons;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels;
using JurisDict.Wpf.ViewModels.CreateReadViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace JurisDict.Wpf.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly INavigation _navigation;

        public ObservableObject CurrentViewModel { get; set; }

        public IEnumerable<NavigationButtonsViewModel> MenuButtons { get; set; }

        public bool ControlButtonsVisibility { get; set; }
        public ICommand DeleteViewModelCommand { get; set; }
        public ICommand UpdateViewModelCommand { get; set; }

        public MainViewModel(INavigation navigation, INavigationButtonBuilder navigationButtonBuilder, DeleteCommandProxy deleteCommandProxy, UpdateCommandProxy updateCommandProxy)
        {
            this._navigation = navigation;
            _navigation.Navigated += OnNavigate;
            MenuButtons = new List<NavigationButtonsViewModel>() {
                navigationButtonBuilder.Build<ClientsViewModel>(new IconButtonViewModel("Клиенты", EIcon.Client)),
                navigationButtonBuilder.Build<ContractsViewModel>(new IconButtonViewModel("Контракты", EIcon.Contract)),
                navigationButtonBuilder.Build<ContractServicesViewModel>(new IconButtonViewModel("Условия контракта", EIcon.ContractServices)),
                navigationButtonBuilder.Build<DepartmentsViewModel>(new IconButtonViewModel("Отделы", EIcon.Department)),
                navigationButtonBuilder.Build<EmployeesViewModel>(new IconButtonViewModel("Сотрудники", EIcon.Employee)),
                navigationButtonBuilder.Build<PositionsViewModel>(new IconButtonViewModel("Должности", EIcon.Position)),
                navigationButtonBuilder.Build<ServicesViewModel>(new IconButtonViewModel("Услуги", EIcon.Services))
            };
            DeleteViewModelCommand = new RelayCommand(() => deleteCommandProxy.Delete());
            UpdateViewModelCommand = new RelayCommand(() => updateCommandProxy.Update());
        }

        private void OnNavigate(ObservableObject vm)
        {
            CurrentViewModel = vm;
            if (CurrentViewModel is not null && !ControlButtonsVisibility)
            {
                ControlButtonsVisibility = true;
            }
        }
    }
}
