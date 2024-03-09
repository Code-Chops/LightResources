namespace CodeChops.LightResources;

internal class LightResourcesService : ILightResourcesService
{
    public static Func<object, string> CultureToIdentifierTranslator { get; set; } = null!;
    public static string DefaultCultureIdentifier { get; set; } = null!;
    public static string CurrentCultureIdentifier => CultureToIdentifierTranslator!(CultureScope.Current.CultureGetter());
}