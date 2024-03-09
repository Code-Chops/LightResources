using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.LightResources;

public static class RegistrationExtensions
{
	public static IServiceCollection AddLightResources(this IServiceCollection services, Func<CultureCode> currentCultureCode,
		CultureCode defaultCultureCode, params LanguageCode[] supportedLanguageCodes)
	{
		var lightResources = new LightResourcesService();

		LightResourcesService.SetDefaultCultureCode(defaultCultureCode);

		foreach (var code in supportedLanguageCodes)
			LightResourcesService.AddSupportedLanguage(code);

		services.AddScoped<ILightResourcesService>(_ => lightResources);

		var defaultScope = new CultureScope(cultureCodeGetter: currentCultureCode, isDefaultScope: true);
		CultureScope.SetDefaultScope(defaultScope);

		return services;
	}
}