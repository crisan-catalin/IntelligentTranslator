using System.Threading.Tasks;
using IntelligentTranslator.Translator.Service;

namespace IntelligentTranslator.Services
{
	public class TranslatorServiceClient : ITranslatorServiceClient
	{
		private readonly WebService _webService = new WebService();

		public async Task<TranslateWordResponseTranslateWordResult> TranslateWordAsync(string word)
		{
			return await Task.Run(() => _webService.TranslateWord(word));
		}

		public string[] GetSimilarWords(string word)
		{
			return _webService.SimilarWords(word);
		}

		TranslateWordResponseTranslateWordResult ITranslatorServiceClient.TranslateWord(string word)
		{
			return _webService.TranslateWord(word);
		}
	}
}