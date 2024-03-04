using Architect.AmbientContexts;

namespace CodeChops.LightResources;

public class CultureScope : AmbientScope<CultureScope>
{
    internal new static void SetDefaultScope(CultureScope defaultScope)
    {
        AmbientScope<CultureScope>.SetDefaultScope(defaultScope);
    }

    /// <summary>
    /// Returns the currently available scope.
    /// If no explicit scope was declared, the default scope is returned.
    /// </summary>
    public static CultureScope Current => GetAmbientScope()!;

    public Func<CultureCode> CultureCodeGetter { get; }

    public CultureScope(Func<CultureCode> cultureCodeGetter)
        : this(cultureCodeGetter, isDefaultScope: false)
    {
    }

    public CultureScope(CultureCode cultureCode)
        : this(() => cultureCode, isDefaultScope: false)
    {
    }

    internal CultureScope(Func<CultureCode> cultureCodeGetter, bool isDefaultScope)
        : base(AmbientScopeOption.ForceCreateNew)
    {
        this.CultureCodeGetter = cultureCodeGetter;

        if (!isDefaultScope)
            this.Activate();
    }

    protected override void DisposeImplementation()
    {
        // Do nothing
    }
}