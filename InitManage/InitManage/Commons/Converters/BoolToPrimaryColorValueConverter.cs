using System;
using System.Globalization;

namespace InitManage.Commons.Converters;

public class BoolToPrimaryColorValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool booleanValue)
        {
            if (booleanValue)
                return  Color.FromHex("E85F22");
        }
        return Color.FromHex("000000");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}

