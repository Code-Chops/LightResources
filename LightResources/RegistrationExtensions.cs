﻿using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.LightResources;

public static class RegistrationExtensions
{
	public static IServiceCollection AddLightResources(this IServiceCollection services, params LanguageCode[] supportedLanguageCodes)
	{
		foreach (var code in supportedLanguageCodes)
			LanguageCodeCache.AddLanguage(code);

		return services;
	}
}