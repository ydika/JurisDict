using JurisDict.Wpf.Dialogs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JurisDict.Wpf.Views.Dialogs.UpdateDialogs
{
    /// <summary>
    /// Логика взаимодействия для PositionUpdateDialog.xaml
    /// </summary>
    public partial class PositionUpdateDialog : Window, IDialog
    {
        public PositionUpdateDialog()
        {
            InitializeComponent();
        }
    }
}
