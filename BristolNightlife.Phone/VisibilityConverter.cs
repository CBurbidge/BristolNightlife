using System;
using System.Globalization;
using System.Windows;

namespace BristolNightlife.Phone
{
	public class VisibilityConverter : System.Windows.Data.IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var boolean = (bool) value;
			return boolean
				? Visibility.Visible
				: Visibility.Collapsed;

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}