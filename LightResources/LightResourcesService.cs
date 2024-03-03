namespace CodeChops.LightResources;

public class LightResourcesService : ILightResourcesService
{
	/// <summary>
	/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
	/// </summary>
	public static LanguageCode DefaultLanguageCode => _defaultLanguageCode ?? throw new InvalidOperationException("Trying to retrieve default language code but it has not been set.");
	private static LanguageCode? _defaultLanguageCode;

	internal void AddLanguage(LanguageCode languageCode)
	{
		SupportedLanguageCodes.CreateMember(languageCode);

		if (_defaultLanguageCode is not null)
			return;

		_defaultLanguageCode = languageCode;
		this.SetCurrentLanguage(languageCode);
	}

	public void SetCurrentLanguage(LanguageCode languageCode)
	{
		if (SupportedLanguageCodes.GetMemberCount() is 0)
			throw new InvalidOperationException("Can't set new language code: no supported language codes have been added.");

		if (!SupportedLanguageCodes.GetMembers(languageCode).Any())
			throw new InvalidOperationException($"Trying to set current languageCode '{languageCode}' but it's not configured as a supported one.");

		SupportedLanguageCodes.GetSingleMember(memberValue: languageCode);
	}
}