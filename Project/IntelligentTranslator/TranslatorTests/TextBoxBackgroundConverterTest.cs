using System.Drawing;
using IntelligentTranslator.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;
using Brushes = System.Drawing.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace TranslatorTests
{
	[TestClass]
	public class TextBoxBackgroundConverterTest
	{
		private TextBoxBackgroundConverter _converter;

		[TestInitialize]
		public void TestInitialize()
		{
			_converter = new TextBoxBackgroundConverter();
		}

		[TestMethod]
		public void Convert_TrueValue_True()
		{
			var result = _converter.Convert(true, null, null, null);
			var color = ((SolidColorBrush)result).Color;

			var expectedColor = (SolidColorBrush)System.Windows.Media.Brushes.GreenYellow;

			Assert.AreEqual(color.ToString(), expectedColor.ToString());
		}

		[TestMethod]
		public void Convert_FalseValue_True()
		{
			var result = _converter.Convert(false, null, null, null);
			var color = ((SolidColorBrush)result).Color;

			var expectedColor = (SolidColorBrush)System.Windows.Media.Brushes.Orange;

			Assert.AreEqual(color.ToString(), expectedColor.ToString());
		}
	}
}
