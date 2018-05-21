using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Xml.Serialization;
using Models;

/// <summary>
///     Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
	private readonly TRANSLATIONS _translations;

	public WebService()
	{
		var xmlSerializer = new XmlSerializer(typeof(TRANSLATIONS));
		using (Stream reader = new FileStream(Server.MapPath("~/App_Data/Intelligent_translator.xml"), FileMode.Open))
		{
			_translations = (TRANSLATIONS)xmlSerializer.Deserialize(reader);
		}
	}

	[WebMethod]
	public TRANSLATIONSRECORD TranslateWord(string word)
	{
		return GetTranslationForWord(word);
	}

	[WebMethod]
	public List<string> SimilarWords(string word)
	{
		return GetSimilarWords(word);
	}

	private TRANSLATIONSRECORD GetTranslationForWord(string word)
	{
		if (string.IsNullOrEmpty(word))
		{
			return null;
		}

		foreach (var translation in _translations.RECORD)
			if (translation.word.ToLower().StartsWith(word.ToLower()))
				return translation;

		return null;
	}

	private List<string> GetSimilarWords(string word)
	{
		return _translations.RECORD.Select(record =>
				new { similarity = CalculateSimilarity(record.word.ToLower(), word.ToLower()), similarWord = record.word })
			.Where(record => record.similarity >= 0.5 && record.similarity < 1)
			.OrderByDescending(record => record.similarity)
			.Select(record => record.similarWord)
			.ToList();
	}

	/// <summary>
	///     Returns the number of steps required to transform the source string
	///     into the target string.
	/// </summary>
	private int ComputeLevenshteinDistance(string source, string target)
	{
		if (source == null || target == null) return 0;
		if (source.Length == 0 || target.Length == 0) return 0;
		if (source == target) return source.Length;

		var sourceWordCount = source.Length;
		var targetWordCount = target.Length;

		if (sourceWordCount == 0)
			return targetWordCount;

		if (targetWordCount == 0)
			return sourceWordCount;

		var distance = new int[sourceWordCount + 1, targetWordCount + 1];

		for (var i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
		for (var j = 0; j <= targetWordCount; distance[0, j] = j++) ;

		for (var i = 1; i <= sourceWordCount; i++)
			for (var j = 1; j <= targetWordCount; j++)
			{
				var cost = target[j - 1] == source[i - 1] ? 0 : 1;
				distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
			}

		return distance[sourceWordCount, targetWordCount];
	}

	/// <summary>
	///     Calculate percentage similarity of two strings
	///     <param name="source">Source String to Compare with</param>
	///     <param name="target">Targeted String to Compare</param>
	///     <returns>Return Similarity between two strings from 0 to 1.0</returns>
	/// </summary>
	private double CalculateSimilarity(string source, string target)
	{
		if (source == null || target == null) return 0.0;
		if (source.Length == 0 || target.Length == 0) return 0.0;
		if (source == target) return 1.0;

		var stepsToSame = ComputeLevenshteinDistance(source, target);
		return 1.0 - stepsToSame / (double)Math.Max(source.Length, target.Length);
	}
}