using System.Threading.Tasks;
using IntelligentTranslator.Translator.Service;

namespace IntelligentTranslator.Services
{
	public interface ITranslatorServiceClient
	{
		Task<TranslateWordResponseTranslateWordResult> TranslateWordAsync(string word);
		TranslateWordResponseTranslateWordResult TranslateWord(string word);
		string[] GetSimilarWords(string word);
	}
}