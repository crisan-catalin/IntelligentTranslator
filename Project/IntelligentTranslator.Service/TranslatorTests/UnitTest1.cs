using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorTests.Translator.Service;

namespace TranslatorTests
{
	[TestClass]
	public class UnitTest1
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
			Console.WriteLine(result);
			Assert.IsTrue(result.Length.Equals(0));
		}

		[TestMethod]
		public void TranslateWord_EmptyString_IsNull()
		{
			var result = _webService.TranslateWord("");

			Assert.IsNull(result);
		}
	}
}
