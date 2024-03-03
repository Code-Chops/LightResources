using Architect.AmbientContexts;

namespace CodeChops.LightResources;

public class LanguageScope : AmbientScope<LanguageScope>
{
    static LanguageScope()
    {
        var defaultScope = new LanguageScope(languageCodeGetter: static () => new LanguageCode("en-GB"), isDefaultScope: true);
        SetDefaultScope(defaultScope);
    }

    /// <summary>
    /// Returns the currently available scope.
    /// If no explicit scope was declared, the default scope is returned.
    /// </summary>
    public static LanguageScope Current => GetAmbientScope()!;

    public Func<LanguageCode> LanguageCodeGetter { get; set; }

    public LanguageScope(Func<LanguageCode> languageCodeGetter)
        : this(languageCodeGetter, isDefaultScope: false)
    {
    }

    public LanguageScope(LanguageCode languageCode)
        : this(() => languageCode, isDefaultScope: false)
    {
    }

    private LanguageScope(Func<LanguageCode> languageCodeGetter, bool isDefaultScope)
        : base(AmbientScopeOption.ForceCreateNew)
    {
        this.LanguageCodeGetter = languageCodeGetter;

        if (!isDefaultScope)
            this.Activate();
    }

    protected override void DisposeImplementation()
    {
        // Do nothing
    }
}