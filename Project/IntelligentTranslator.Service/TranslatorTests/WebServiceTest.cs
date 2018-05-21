using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorTests.Translator.Service;

namespace TranslatorTests
{
	[TestClass]
	public class WebServiceTest
	{

		private WebService _webService;

		[TestInitialize]
		public void TestInitialize()
		{
			_webService = new WebService();
		}

		[TestMethod]
		public void SimilarWords_EmptyString_True()
		{
			var result = _webService.SimilarWords("");

			Assert.AreEqual(0, result.Length);
		}

		[TestMethod]
		public void TranslateWord_EmptyString_IsNull()
		{
			var result = _webService.TranslateWord("");

			Assert.IsNull(result);
		}
	}
}
