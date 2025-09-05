using System.Globalization;

namespace TipCalc.Converters
{
    public class EntryNotNegativeValidatorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is not null && double.TryParse(value.ToString(), out double result) && result > 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
