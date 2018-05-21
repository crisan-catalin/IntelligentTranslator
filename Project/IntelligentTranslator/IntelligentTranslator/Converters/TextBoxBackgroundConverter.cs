using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace IntelligentTranslator.Converters
{
	public class TextBoxBackgroundConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToBoolean(value) ? Brushes.GreenYellow : Brushes.Orange;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}