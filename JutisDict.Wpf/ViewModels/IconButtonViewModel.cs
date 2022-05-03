using JurisDict.Wpf.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.ViewModels
{
    public class IconButtonViewModel
    {
        public string Content { get; set; }
        public EIcon Icon { get; set; }

        public IconButtonViewModel(string content, EIcon icon)
        {
            Content = content;
            Icon = icon;
        }
    }
}
