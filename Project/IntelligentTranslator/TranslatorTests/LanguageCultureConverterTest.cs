using System;
using IntelligentTranslator.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslatorTests
{
	[TestClass]
	public class LanguageCultureConverterTest
	{
		private LanguageCultureConverter _converter;

		[TestInitialize]
		public void TestInitialize()
		{
			_converter = new LanguageCultureConverter();
		}

		[TestMethod]
		public void Convert_EmptryString_True()
		{
			var result = _converter.Convert("", null, null, null);

			Assert.AreEqual(result, "(-)");
		}

		[TestMethod]
		public void Convert_GoodCultureString_True()
		{
			var result = _converter.Convert("de-DE", null, null, null);

			Assert.AreEqual(result, "DE");
		}
	}
}
