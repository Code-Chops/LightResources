using System.Text.RegularExpressions;
using Architect.DomainModeling;

namespace CodeChops.LightResources;

[WrapperValueObject<string>]
public sealed partial class LanguageCode : IComparable<LanguageCode>
{
    public override string ToString() => this.Value;
    protected override StringComparison StringComparison => StringComparison.OrdinalIgnoreCase;

    [GeneratedRegex("^[a-zA-Z]{2}$")]
    private static partial Regex ValidationRegex();

    public LanguageCode(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        var match = ValidationRegex().Match(value);
        if (!match.Success)
            throw new ArgumentException($"Invalid language code: {value}");

        this.Value = value;
    }
}