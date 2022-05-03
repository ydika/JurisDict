using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels;
using JurisDict.Wpf.ViewModels.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace JurisDict.Wpf.ViewModels
{
    public class NavigationButtonsViewModel : ObservableObject
    {
        public IconButtonViewModel Properties { get; set; }

        public ICommand ClickCommand { get; set; }

        public NavigationButtonsViewModel(IconButtonViewModel properties)
        {
            Properties = properties;
        }
    }

    public class NavigationButtonViewModel<TViewModel> : NavigationButtonsViewModel where TViewModel : ObservableObject, IAsyncLoadable
    {
        private readonly INavigation _navigation;

        public NavigationButtonViewModel(INavigation navigation, IconButtonViewModel properties) : base(properties)
        {
            this._navigation = navigation;
            ClickCommand = new RelayCommand(Click);
        }

        private void Click()
        {
            _navigation.Navigate<TViewModel>();
        }
    }
}
