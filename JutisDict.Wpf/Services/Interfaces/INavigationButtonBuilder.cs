using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.ViewModels;
using JurisDict.Wpf.ViewModels.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace JurisDict.Wpf.Services.Interfaces
{
    public interface INavigationButtonBuilder
    {
        NavigationButtonsViewModel Build<TViewModel>(IconButtonViewModel properties) where TViewModel : ObservableObject, IAsyncLoadable;
    }
}
