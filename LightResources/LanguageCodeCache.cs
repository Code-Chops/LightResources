namespace CodeChops.LightResources;

public static class LanguageCodeCache
{
	/// <summary>
	/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
	/// </summary>
	public static LanguageCode DefaultLanguageCode => _defaultLanguageCode ?? throw new InvalidOperationException("Trying to retrieve default language code but it has not been set.");
	private static LanguageCode? _defaultLanguageCode;
	
	/// <summary>
	/// The current displayed language code. The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
	/// </summary>
	public static LanguageCode CurrentLanguageCode { get; private set; }
	
	public static bool CurrentLanguageCodeIsDefault { get; private set; } = true;
	
	/// <summary>
	/// Takes the first 2 letters of <see cref="CurrentLanguageCode"/> and converts it to upper invariant.
	/// </summary>
	public static string? CurrentSimpleLanguageCode { get; private set; }

	internal static void AddLanguage(LanguageCode languageCode)
	{
		SupportedLanguageCodes.CreateMember(languageCode);
		
		if (_defaultLanguageCode is null)
		{
			_defaultLanguageCode = languageCode;
			SetCurrentLanguage(languageCode);
		}
	}
	
	public static void SetCurrentLanguage(LanguageCode languageCode)
	{
		if (SupportedLanguageCodes.GetMemberCount() == 0)
			throw new InvalidOperationException("Can't set new language code: no supported language codes have been added.");

		if (!SupportedLanguageCodes.GetMembers(languageCode).Any())
			throw new InvalidOperationException($"Trying to set current languageCode '{languageCode}' but it's not configured as a supported one.");
			
		SupportedLanguageCodes.GetSingleMember(memberValue: languageCode);
		
		CurrentLanguageCode = languageCode;
		CurrentLanguageCodeIsDefault = CurrentLanguageCode == DefaultLanguageCode;
		CurrentSimpleLanguageCode = CurrentLanguageCode.GetSimpleLanguageCode().ToUpperInvariant();
	}
}
