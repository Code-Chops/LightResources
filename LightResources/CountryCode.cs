using System.Text.RegularExpressions;

namespace CodeChops.LightResources;

/// <summary>
/// An upper-case country code (ISO 3166-1 alpha-2).
/// </summary>
[GenerateStringValueObject(minimumLength: 2, maximumLength: 2,
 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, stringFormat: StringFormat.Alpha,
    stringCaseConversion: StringCaseConversion.UpperInvariant, propertyIsPublic: true, useRegex: true,
    useValidationExceptions: false)]
public partial record struct CountryCode
{
	[GeneratedRegex("/^[a-z]{2}$/")]
	public static partial Regex ValidationRegex();
}