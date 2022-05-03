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
    public class DepartmentViewModel : ObservableObject, IDeletable, IUpdatable<Department>, IDialogRequestClose
    {
        public Department Model { get; set; }

        public bool IsChecked { get; set; }
        public Guid Id => Model.Id;

        public bool IsUpdated { get; set; } = false;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequest;
        public ICommand DepartmentUpdateShowDialog { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public DepartmentViewModel(IDialogService dialogService)
        {
            DepartmentUpdateShowDialog = new RelayCommand(() => ResultHandler(dialogService));
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
