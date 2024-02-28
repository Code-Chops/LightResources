using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace CodeChops.LightResources;

public abstract class ResourcedComponent : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; init; } = null!;

    private event Action? LanguageChangedEvent;

    protected override void OnInitialized()
    {
        this.OnComponentInitialized();

        this.LanguageChangedEvent += this.OnLanguageChanged;
        this.NavigationManager.LocationChanged += this.OnLanguageChanged;
    }

    private void OnLanguageChanged(object? sender, LocationChangedEventArgs e)
    {
        this.OnLanguageChanged();
    }

    protected virtual void OnComponentInitialized()
    {
    }

    protected void TriggerLanguageChangedEvent()
    {
        this.LanguageChangedEvent?.Invoke();
    }

    private void OnLanguageChanged()
    {
        this.InvokeAsync(this.StateHasChanged);
    }

    public void Dispose()
    {
        this.LanguageChangedEvent -= this.OnLanguageChanged;
        this.NavigationManager.LocationChanged -= this.OnLanguageChanged;
    }
}