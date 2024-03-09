using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.LightResources;

public static class RegistrationExtensions
{
	public static IServiceCollection AddLightResources<TCulture>(this IServiceCollection services, TCulture defaultCulture,
		Func<TCulture> currentCultureGetter, Func<TCulture, string> cultureToIdentifierTranslator)
	{
		var defaultScope = new CultureScope(cultureGetter: () => currentCultureGetter()!, isDefaultScope: true);
		CultureScope.SetDefaultScope(defaultScope);

		LightResourcesService.CultureToIdentifierTranslator = culture => cultureToIdentifierTranslator((TCulture)culture);
		LightResourcesService.DefaultCultureIdentifier = cultureToIdentifierTranslator(defaultCulture);

		return services;
	}
}