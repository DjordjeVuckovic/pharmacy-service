using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using TechHealth.Model;

namespace TechHealth.Conversions
{
    class AddressConverter:MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Address address= (Address)value;
            return address.Street + "," + address.StreetNumber + "," + address.City + "," + address.Postcode + "," + address.Country;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    
}
