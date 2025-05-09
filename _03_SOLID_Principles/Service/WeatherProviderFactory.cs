
namespace _03_SOLID_Principles.Service;

public class WeatherProviderFactory : IWeatherProviderFactory {
    public IWeatherProvider CreateProvider(WeatherProviderType type) {
        return type switch {
            WeatherProviderType.OpenWeatherMap => new OpenWeatherMapProvider(),
            WeatherProviderType.AccuWeather => new AccuWeatherProvider(),
            _ => throw new ArgumentException($"Invalid weather provider type: {type}")
        };
    }
}