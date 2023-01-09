# Light resources 
#### _Lightweight dynamic resources for your Blazor website_

LightResources is a Blazor base component for enabling lightweight text resources for a Blazor WebAssembly website.
When using the default .NET solution for localization, Blazor has to refresh the website in order to fetch and load the satellite DLL which contains the non-default resource.
This is slow and cumbersome. LightResources fixes this problem by loading the resources statically when starting the application. Now the language can be changed dynamically on your page.

> This package works on every hosting model: Blazor WebAssembly (ASP.NET core hosted) or Blazor ServerSide. 

> Check out www.CodeChops.nl to see this package in action, and to see more projects.

# Advantages
- The page does not need to be refreshed when switching the current UI language. So you get a real SPA.
- The resources are lightweight and fast.
- The .NET `CultureInfo` does not have to be used, so your Blazor WebAssembly application will be smaller.
- Resources can be searched through.
- Easy implementation.
- Reference a resource the same way as in traditional .resx files: `@HomeResource.Title`.

> This package makes use of [MagicEnums](https://github.com/Code-Chops/MagicEnums) and [Implementation discovery](https://github.com/Code-Chops/ImplementationDiscovery) under the hood.

# Getting started

1. Install the package `CodeChops.LightResources` in your Blazor project.
2. Add `builder.Services.AddLightResources()` to your `Program.cs` and provide the language codes you want to support.
3. Optional: Set the current language code by calling `LanguageCodeCache.SetLanguageCode()`. If this step is omitted, the first provided language code will be set as default.
4. Create a component and inherit it from `ResourcedComponent`: `@inherits ResourcedComponent`
5. Create a new file (as code behind, for example `HomePage.razor.cs`).
6. Create a record with a name. Suffix the name with the simple language code in upper case for non-default language resources.
7. Implement the base class `Resource` for each language. The type parameters that should be provided to the base class are:
    - The current resource implementation `TSelf`.
    - All discovered resource implementations of the project, to be found in `CodeChops.LightResources.ResourceProxyEnum`.

# Example
Add the following to your Program.cs:
```csharp
builder.Services.AddLightResources(new LanguageCode[] { new("en-GB"), new("nl-NL") });
```

Create a new resource file and add the following:
```csharp
namespace CodeChops.Website.Client.Pages.Home;

public record HomeResource : Resource<HomeResource, ResourceProxyEnum>
{
	public static string Title	=> CreateMember(@"
Welcome
");
	
	public static string Author	=> CreateMember(@"
Logo, design and website by CodeChops
");
}

public record HomeResourceNL : Resource<HomeResourceNL, ResourceProxyEnum>
{
	public static string Title { get; }	= CreateMember(@"
Welkom
");

	public static string Author { get; }	= CreateMember(@"
Logo, design en website door CodeChops
");
}
```

> Resources will automatically be trimmed.

> Note that the default language should have expression bodied properties.
> This will forward your call to the resource in the current language (when the language is non-default).

The resource can now be called from a razor file:

```html
<Title>@HomeResource.Title</Title>
```

## API

## LanguageCode
The default ISO 639-1 language code with a 2-letter country code (ISO 3166-1 alpha-2) where relevant, for example: "en-GB".
`CultureInfo` is not used in this library in order to reduce package size. 

> No check takes place if the language code is an existing language code. This can be done by using `CultureInfo` if needed.

### LanguageCodeCache

| Member                         | Description                                                                            |
|--------------------------------|----------------------------------------------------------------------------------------|
| `DefaultLanguageCode`          | Retrieves the default language code.                                                   |
| `CurrentLanguageCode`          | Retrieves the currently displayed language code.                                       |
| `CurrentLanguageCodeIsDefault` | Returns `true` when the current displayed language code is the default language code.  | 
| `CurrentSimpleLanguageCode`    | Takes the first 2 letters of `CurrentLanguageCode` and converts it to upper invariant. |
| `SetCurrentLanguage()`         | Sets the current displayed language code.                                              | 

The resource managers make of MagicEnums under the hood, so the base API is the same as the [MagicEnum API](https://github.com/Code-Chops/MagicEnums/#).
This API can be used to search for or add resources at runtime:

| Method                | Description                                                                                                                      |
|-----------------------|----------------------------------------------------------------------------------------------------------------------------------|
| `CreateMember`        | Creates a new discovered implementation member and returns it.                                                                   |
| `GetEnumerator`       | Gets an enumerator over the enum members.                                                                                        |
| `GetMembers`          | Gets an enumerable over:<br/>- All enum members, or<br/>- Members of a specific value: **Throws when no member has been found.** |
| `GetValues`           | Gets an enumerable over the member values.                                                                                       |
| `TryGetMembers`       | Tries to get member(s) by value.                                                                                                 |
| `TryGetSingleMember`  | Tries to get a single member by name / value.<br/>**Throws when multiple members of the same value have been found.**            |
| `GetSingleMember`     | Gets a single member by name / value.<br/>**Throws when not found or multiple members have been found.**                         |
| `GetUniqueValueCount` | Gets the unique member value count.                                                                                              |
| `GetMemberCount`      | Gets the member count.                                                                                                           |
| `GetDefaultValue`     | Gets the default value of the enum.                                                                                              |
| `GetOrCreateMember`   | Creates a member or gets one if a member already exists.                                                                         |

