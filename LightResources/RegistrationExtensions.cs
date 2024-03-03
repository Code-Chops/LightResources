using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.LightResources;

public static class RegistrationExtensions
{
	public static IServiceCollection AddLightResources(this IServiceCollection services, Func<LanguageCode>? languageCodeGetter = null,
		params LanguageCode[] supportedLanguageCodes)
	{
		var lightResources = new LightResourcesServiceService();

		foreach (var code in supportedLanguageCodes)
			lightResources.AddLanguage(code);

		services.AddScoped<ILightResourcesService>(_ => lightResources);

		languageCodeGetter ??= supportedLanguageCodes.Length is not 0
			? supportedLanguageCodes.First
			: static () => new LanguageCode("en-US");

		var defaultScope = new LanguageScope(languageCodeGetter: languageCodeGetter, isDefaultScope: true);
		LanguageScope.SetDefaultScope(defaultScope);

		return services;
	}
}