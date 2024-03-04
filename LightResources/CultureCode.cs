using System.Text.RegularExpressions;

namespace CodeChops.LightResources;

/// <summary>
/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
/// </summary>
[GenerateStringValueObject(minimumLength: 5, maximumLength: 10,
 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, stringFormat: StringFormat.Default,
    stringCaseConversion: StringCaseConversion.NoConversion, propertyIsPublic: true, useRegex: true,
    generateDefaultConstructor: false, useValidationExceptions: false)]
public partial record struct CultureCode
{
	[GeneratedRegex("/^[a-z]{2,3}(?:-[a-zA-Z]{4})?(?:-[A-Z]{2,3})?$/")]
	public static partial Regex ValidationRegex();

	public CultureCode(string value, Validator? validator = null)
	{
		this._value = value;

		var values = value.Split('-');
		this.LanguageCode = new(values[0]);
		this.CountryCode = new(values[1]);
	}

	/// <summary>
	/// Gets the first part of the ISO 639-1 language code "en-GB" -> "EN".
	/// </summary>
	public LanguageCode LanguageCode { get; }

	/// <summary>
	/// Gets the last part of the ISO 639-1 language code "en-GB" -> "GB".
	/// </summary>
	public CountryCode CountryCode { get; }
}