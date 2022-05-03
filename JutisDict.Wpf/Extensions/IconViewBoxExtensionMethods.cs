using JurisDict.Wpf.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JurisDict.Wpf.Extensions
{
    public static class IconViewBoxExtensionMethods
    {
        public static Path CreatePath(this EIcon icon, Brush foregroundBrush)
        {
            var svgString = GetSvgString(icon);
            if (svgString is null) return null;
            Path path = new()
            {
                Data = Geometry.Parse(svgString),
                Fill = foregroundBrush,
                Stretch = Stretch.Uniform
            };
            return path;
        }

        public static string GetSvgString(this EIcon icon)
        {
            if (IconDictionary.Icons.TryGetValue(icon, out string svgString) || svgString is not null)
            {
                return svgString;
            }
            return null;
        }
    }
}
