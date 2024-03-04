using Architect.AmbientContexts;

namespace CodeChops.LightResources;

public class LanguageScope : AmbientScope<LanguageScope>
{
    internal new static void SetDefaultScope(LanguageScope defaultScope)
    {
        AmbientScope<LanguageScope>.SetDefaultScope(defaultScope);
    }

    /// <summary>
    /// Returns the currently available scope.
    /// If no explicit scope was declared, the default scope is returned.
    /// </summary>
    public static LanguageScope Current => GetAmbientScope()!;

    public Func<CultureCode> LanguageCodeGetter { get; }

    public LanguageScope(Func<CultureCode> languageCodeGetter)
        : this(languageCodeGetter, isDefaultScope: false)
    {
    }

    public LanguageScope(CultureCode cultureCode)
        : this(() => cultureCode, isDefaultScope: false)
    {
    }

    internal LanguageScope(Func<CultureCode> languageCodeGetter, bool isDefaultScope)
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