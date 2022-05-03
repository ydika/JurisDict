using Microsoft.Extensions.DependencyInjection;
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
    public class NavigationService : INavigation
    {
        private readonly IServiceProvider _serviceProvider;

        public event Action<ObservableObject> Navigated;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Navigate<TViewModel>() where TViewModel : ObservableObject, IAsyncLoadable
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>();
            vm.LoadAsync();
            Navigated?.Invoke(vm);
        }
    }
}
