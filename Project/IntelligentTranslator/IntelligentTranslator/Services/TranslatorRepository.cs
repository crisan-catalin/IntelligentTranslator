using IntelligentTranslator.Translator.Service;

namespace IntelligentTranslator.Services
{
	public class TranslatorRepository : ITranslatorRepository
	{
		private readonly WebService _webService = new WebService();

		public TranslateWordResponseTranslateWordResult TranslateWord(string word)
		{
			return _webService.TranslateWord(word);
		}

		public string[] GetSimilarWords(string word)
		{
			return _webService.SimilarWords(word);
		}
	}
}