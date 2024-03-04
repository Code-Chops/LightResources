using CodeChops.MagicEnums;

namespace CodeChops.LightResources;

public record SupportedLanguageCodes : MagicCustomEnum<SupportedLanguageCodes, LanguageCode>
{
 	public static SupportedLanguageCodes CreateMember(LanguageCode languageCode)
		=> CreateMember(value: languageCode, name: languageCode.Value);
}