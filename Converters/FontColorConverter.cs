using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;


namespace Caliburn.Micro.Hello
{
    public class FontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fontColor = (Color)value;
            if (fontColor == Color.Black)
            {
                return "Black";
            }
            else
            {
                return "DimGray";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
