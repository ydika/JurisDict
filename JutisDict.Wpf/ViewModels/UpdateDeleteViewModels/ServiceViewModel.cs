using Common.Models;
using JurisDict.Wpf.Dialogs;
using JurisDict.Wpf.Dialogs.Interfaces;
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
    public class ServiceViewModel : ObservableObject, IDeletable, IUpdatable<Service>, IDialogRequestClose
    {
        public Service Model { get; set; }

        public bool IsDelete { get; set; }
        public Guid Id => Model.Id;

        public bool IsUpdated { get; set; }
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;
        public ICommand ServiceUpdateShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public ServiceViewModel(IDialogService dialogService)
        {
            ServiceUpdateShowDialog = new RelayCommand(() => ResultHandler(dialogService));
            OkCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(() => CloseRequest?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public void ResultHandler(IDialogService dialogService)
        {
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
