using CodeChops.MagicEnums;

namespace CodeChops.LightResources;

public record SupportedLanguageCodes : MagicCustomEnum<SupportedLanguageCodes, CultureCode>
{
 	public static SupportedLanguageCodes CreateMember(CultureCode cultureCode)
		=> CreateMember(value: cultureCode, name: cultureCode.Value);
}