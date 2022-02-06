using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace bo1tool.Converters
{
    class colorHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ColorTranslator.ToHtml((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color val = (Color)System.Windows.Media.ColorConverter.ConvertFromString((String)value);
            return val;
        }
    }
}
