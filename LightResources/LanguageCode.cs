using System.Text.RegularExpressions;

namespace CodeChops.LightResources;

/// <summary>
/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
/// </summary>
[GenerateStringValueObject(minimumLength: 2, maximumLength: 5,
 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, stringFormat: StringFormat.Default, stringCaseConversion: StringCaseConversion.NoConversion,
    propertyIsPublic: true, useRegex: true, useValidationExceptions: false)]
public partial record struct LanguageCode
{
	[GeneratedRegex("^[a-z]{2}-[A-Z]{2}$")]
	public static partial Regex ValidationRegex();

	/// <summary>
	/// Gets the first part of the ISO 639-1 language code "en-GB" -> "en".
	/// </summary>
	public string GetSimpleLanguageCode()	=> this.Value.Split('-')[0];

	/// <summary>
	/// Gets the last part of the ISO 639-1 language code "en-GB" -> "GB".
	/// </summary>
	public string GetCountryCode()			=> this.Value.Split('-')[1];
}