using JurisDict.Wpf.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JurisDict.Wpf.Extensions
{
    public class IconButton : Button
    {
        public static readonly DependencyProperty IconProperty;
        public static readonly DependencyProperty TextProperty;

        static IconButton()
        {
            IconProperty = DependencyProperty.Register(nameof(Icon), typeof(EIcon), typeof(IconButton), new PropertyMetadata(EIcon.None));
            TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(IconButton), new PropertyMetadata(default(string)));
        }

        public EIcon Icon
        {
            get { return (EIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
