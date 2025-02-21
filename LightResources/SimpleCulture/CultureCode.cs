using System.Text.RegularExpressions;
using Architect.DomainModeling;

namespace CodeChops.LightResources.SimpleCulture;

/// <summary>
/// The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant: "en-GB".
/// </summary>
[WrapperValueObject<string>]
public sealed partial class CultureCode : IComparable<CultureCode>
{
    [GeneratedRegex("/^[a-z]{2,3}(?:-[a-zA-Z]{4})?(?:-[A-Z]{2,3})?$/")]
    private static partial Regex ValidationRegex();
    protected override StringComparison StringComparison => StringComparison.OrdinalIgnoreCase;

    public CultureCode(string value)
    {
        var values = value.Split('-').ToList();

        var match = ValidationRegex().Match(value);
        if (!match.Success)
            throw new ArgumentException($"Invalid language code: {value}");

        this.LanguageCode = new(values[0]);
        this.CountryCode = new(values[1]);

        this.Value = value;
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