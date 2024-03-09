namespace CodeChops.LightResources;

public class LightResourcesService : ILightResourcesService
{
	/// <summary>
	/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
	/// </summary>
	public static CultureCode DefaultCultureCode => _defaultCultureCode
	                                                ?? throw new InvalidOperationException("Trying to retrieve default culture code but it has not been set.");
	private static CultureCode? _defaultCultureCode;

	internal static void SetDefaultCultureCode(CultureCode cultureCode)
	{
		if (_defaultCultureCode is not null)
			throw new InvalidOperationException("Default culture code has already been set.");

		SupportedLanguageCodes.CreateMember(cultureCode.LanguageCode);

		_defaultCultureCode = cultureCode;
	}

	internal static void AddSupportedLanguage(LanguageCode languageCode)
	{
		SupportedLanguageCodes.CreateMember(languageCode);
	}
}