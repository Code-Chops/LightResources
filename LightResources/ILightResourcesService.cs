namespace CodeChops.LightResources;

public interface ILightResourcesService
{
    /// <summary>
    /// The current displayed language code. The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
    /// </summary>
    LanguageCode CurrentLanguageCode { get; }

    void SetCurrentLanguage(LanguageCode languageCode);
}