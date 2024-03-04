using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.LightResources;

public static class RegistrationExtensions
{
	public static IServiceCollection AddLightResources(this IServiceCollection services, Func<CultureCode> currentLanguageCodeGetter,
		CultureCode defaultCultureCode, params CultureCode[] supportedLanguageCodes)
	{
		var lightResources = new LightResourcesService();

		lightResources.AddLanguage(defaultCultureCode);

		foreach (var code in supportedLanguageCodes)
			lightResources.AddLanguage(code);

		services.AddScoped<ILightResourcesService>(_ => lightResources);

		var defaultScope = new LanguageScope(languageCodeGetter: currentLanguageCodeGetter, isDefaultScope: true);
		LanguageScope.SetDefaultScope(defaultScope);

		return services;
	}
}