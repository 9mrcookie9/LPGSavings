using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace LPGSavings.Converters
{
    public class FloatConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0";
            float fValue = (float)value;
            return fValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                strValue = "0";
            float valueFloat;
            if (float.TryParse(strValue, out valueFloat))
            {
                if (strValue.Last() == ',')
                    return valueFloat + ",";
                return valueFloat;
            }
            return 0;
        }

    }
}
