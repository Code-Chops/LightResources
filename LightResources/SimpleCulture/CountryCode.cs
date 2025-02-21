using System.Text.RegularExpressions;
using Architect.DomainModeling;

namespace CodeChops.LightResources.SimpleCulture;

/// <summary>
/// An upper-case country code (ISO 3166-1 alpha-2).
/// </summary>
[WrapperValueObject<string>]
public sealed partial class CountryCode : IComparable<CountryCode>
{
    public override string ToString() => this.Value;
    protected override StringComparison StringComparison => StringComparison.OrdinalIgnoreCase;

    [GeneratedRegex("^[a-zA-Z]{2}$")]
    private static partial Regex ValidationRegex();

    public CountryCode(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        var match = ValidationRegex().Match(value);
        if (!match.Success)
            throw new ArgumentException($"Invalid language code: {value}");

        this.Value = value;
    }
}