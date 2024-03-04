using System.Text.RegularExpressions;

namespace CodeChops.LightResources;

/// <summary>
/// An upper-case (ISO 639) language code.
/// </summary>
[GenerateStringValueObject(minimumLength: 2, maximumLength: 2,
 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, stringFormat: StringFormat.Alpha,
    stringCaseConversion: StringCaseConversion.UpperInvariant, propertyIsPublic: true, useRegex: true,
    useValidationExceptions: false)]
public partial record struct LanguageCode
{
	[GeneratedRegex("/^[a-z][A-Z]{2}$/")]
	public static partial Regex ValidationRegex();
}