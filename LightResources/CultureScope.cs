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

    public Func<object> CultureGetter { get; }

    public CultureScope(Func<object> cultureGetter)
        : this(cultureGetter, isDefaultScope: false)
    {
    }

    public CultureScope(object culture)
        : this(() => culture, isDefaultScope: false)
    {
    }

    internal CultureScope(Func<object> cultureGetter, bool isDefaultScope)
        : base(AmbientScopeOption.ForceCreateNew)
    {
        this.CultureGetter = cultureGetter;

        if (!isDefaultScope)
            this.Activate();
    }

    protected override void DisposeImplementation()
    {
        // Do nothing
    }
}