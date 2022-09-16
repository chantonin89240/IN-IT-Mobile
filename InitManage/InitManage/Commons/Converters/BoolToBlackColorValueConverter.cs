using System;
using System.Globalization;

namespace InitManage.Commons.Converters;

public class BoolToBlackColorValueConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool booleanValue)
        {
            if (booleanValue)
                return Color.FromHex("000000");
        }
        return Color.FromHex("FFFFFF");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

