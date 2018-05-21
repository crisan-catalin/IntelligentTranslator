using IntelligentTranslator.Translator.Service;

namespace IntelligentTranslator.Services
{
	public interface ITranslatorRepository
	{
		TranslateWordResponseTranslateWordResult TranslateWord(string word);
		string[] GetSimilarWords(string word);
	}
}