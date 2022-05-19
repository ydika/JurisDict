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
        public static readonly DependencyProperty CornerRadiusProperty;
        public static readonly DependencyProperty IconProperty;
        public static readonly DependencyProperty IconSizeProperty;
        public static readonly DependencyProperty TextProperty;

        static IconButton()
        {
            CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(IconButton), new PropertyMetadata(default(CornerRadius)));
            IconProperty = DependencyProperty.Register(nameof(Icon), typeof(EIcon), typeof(IconButton), new PropertyMetadata(EIcon.None));
            IconSizeProperty = DependencyProperty.Register(nameof(IconSize), typeof(double), typeof(IconButton), new PropertyMetadata(16d));
            TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(IconButton), new PropertyMetadata(default(string)));
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public EIcon Icon
        {
            get { return (EIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
