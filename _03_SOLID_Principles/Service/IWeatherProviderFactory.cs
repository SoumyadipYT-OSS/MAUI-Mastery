
namespace _03_SOLID_Principles.Service;

// Factory Pattern: This interface defines a method to create different weather providers.
public interface IWeatherProviderFactory {
    IWeatherProvider CreateProvider(WeatherProviderType type);
}
