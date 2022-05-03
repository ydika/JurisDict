using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.ViewModels;
using JurisDict.Wpf.ViewModels.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace JurisDict.Wpf.Services
{
    public class NavigationButtonBuilder : INavigationButtonBuilder
    {
        private readonly INavigation _navigation;

        public NavigationButtonBuilder(INavigation navigation)
        {
            this._navigation = navigation;
        }

        public NavigationButtonsViewModel Build<TViewModel>(IconButtonViewModel properties) where TViewModel : ObservableObject, IAsyncLoadable
        {
            return new NavigationButtonViewModel<TViewModel>(_navigation, properties);
        }
    }
}
