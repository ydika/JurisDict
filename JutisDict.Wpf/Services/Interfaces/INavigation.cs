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
    public interface INavigation
    {
        event Action<ObservableObject> Navigated;

        void Navigate<TViewModel>() where TViewModel : ObservableObject, IAsyncLoadable;
    }
}
