using System;
using System.Globalization;
using System.Windows.Data;

namespace IntelligentTranslator.Converters
{
	public class LanguageCultureConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string languageCulture = value?.ToString();
			if (string.IsNullOrEmpty(languageCulture))
			{
				return "(-)";
			}

			var prefix = languageCulture.Substring(0, languageCulture.IndexOf('-'));
			return prefix.ToUpper();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}