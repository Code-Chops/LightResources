using Architect.AmbientContexts;

namespace CodeChops.LightResources;

public class LanguageScope : AmbientScope<LanguageScope>
{
    static LanguageScope()
    {
        var defaultScope = new LanguageScope(languageCode: new LanguageCode("en-GB"), isDefaultScope: true);
        SetDefaultScope(defaultScope);
    }

    /// <summary>
    /// Returns the currently available scope.
    /// If no explicit scope was declared, the default scope is returned.
    /// </summary>
    public static LanguageScope Current => GetAmbientScope()!;

    public LanguageCode LanguageCode { get; set; }

    public LanguageScope(LanguageCode languageCode)
        : this(languageCode, isDefaultScope: false)
    {
    }

    private LanguageScope(LanguageCode languageCode, bool isDefaultScope)
        : base(AmbientScopeOption.ForceCreateNew)
    {
        this.LanguageCode = languageCode;

        if (!isDefaultScope)
            this.Activate();
    }

    protected override void DisposeImplementation()
    {
        // Do nothing
    }
}