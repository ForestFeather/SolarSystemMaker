using SolarSystemLibrary.enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SolarSystemMaker.Views
{
    public class EnumDescriptionConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string ? value : value is Enum ? ((Enum)value).GetDescription() : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
