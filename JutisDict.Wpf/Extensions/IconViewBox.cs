using JurisDict.Wpf.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JurisDict.Wpf.Extensions
{
    public class IconViewBox : Viewbox
    {
        public static readonly DependencyProperty ForegroundProperty;
        public static readonly DependencyProperty IconProperty;

        static IconViewBox()
        {
            ForegroundProperty = DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(IconViewBox), new PropertyMetadata(Brushes.Black, new PropertyChangedCallback(OnIconPropertyChanged)));
            IconProperty = DependencyProperty.Register(nameof(Icon), typeof(EIcon), typeof(IconViewBox), new PropertyMetadata(EIcon.None, new PropertyChangedCallback(OnIconPropertyChanged)));
        }

        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public EIcon Icon
        {
            get { return (EIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private static void OnIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IconViewBox iconViewBox = d as IconViewBox;
            if (iconViewBox.Icon == EIcon.None)
            {
                iconViewBox.Child = null;
            }
            else
            {
                iconViewBox.Child = iconViewBox.Icon.CreatePath(iconViewBox.Foreground);
            }
        }
    }
}
