namespace CodeChops.LightResources;

internal interface ILightResourcesService
{
    public static abstract Func<object, string> CultureToIdentifierTranslator { get; }
    public static abstract string DefaultCultureIdentifier { get; }
}