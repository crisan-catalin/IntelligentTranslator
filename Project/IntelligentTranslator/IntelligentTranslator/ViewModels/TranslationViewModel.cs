using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using IntelligentTranslator.Properties;
using IntelligentTranslator.Services;
using IntelligentTranslator.Translator.Service;

namespace IntelligentTranslator.ViewModels
{
	public class TranslationViewModel : ViewModelBase
	{
		private readonly ITranslatorServiceClient _serviceClient = new TranslatorServiceClient();

		private string _translationWord;
		private string _translatedWordLanguage;
		private string _translationPlaceholder = Resources.enter_word;
		private bool _wordFound;
		private ObservableCollection<TranslateWordResponseTranslateWordResultLINK> _wordTranslations;
		private ObservableCollection<string> _similarWords;

		public string TranslationWord
		{
			get { return _translationWord; }
			set
			{
				_translationWord = value.ToLower();

				UpdateViewAsync(value);
			}
		}

		public string TranslatedWordLanguage
		{
			get { return _translatedWordLanguage; }
			set { SetProperty(ref _translatedWordLanguage, value); }
		}

		public string TranslationPlaceholder
		{
			get { return _translationPlaceholder; }
			set { SetProperty(ref _translationPlaceholder, value); }
		}

		public bool WordFound
		{
			get { return _wordFound; }
			set { SetProperty(ref _wordFound, value); }
		}

		public ObservableCollection<TranslateWordResponseTranslateWordResultLINK> WordTranslations
		{
			get { return _wordTranslations; }
			set { SetProperty(ref _wordTranslations, value); }
		}

		public ObservableCollection<string> SimilarWords
		{
			get { return _similarWords; }
			set { SetProperty(ref _similarWords, value); }
		}

		private async void UpdateViewAsync(string word)
		{
			try
			{
				var translateResult = await _serviceClient.TranslateWordAsync(word);
				if (translateResult != null)
				{
					TranslationPlaceholder = translateResult.word.ToLower();
					TranslatedWordLanguage = translateResult.culture;

					WordFound = word.Equals(TranslationPlaceholder);
					WordTranslations = new ObservableCollection<TranslateWordResponseTranslateWordResultLINK>(translateResult.LINK);
				}
				else
				{
					TranslationPlaceholder = string.IsNullOrWhiteSpace(word) ? Resources.enter_word : null;
					TranslatedWordLanguage = null;
					WordTranslations = null;
				}

				SimilarWords = new ObservableCollection<string>(_serviceClient.GetSimilarWords(word));
			}
			catch (WebException)
			{
				TranslationPlaceholder = string.IsNullOrWhiteSpace(word) ? Resources.enter_word : null;

				MessageBox.Show(Resources.webservice_error, Resources.error);
			}
		}
	}
}