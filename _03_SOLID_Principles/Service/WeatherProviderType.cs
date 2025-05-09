
namespace _03_SOLID_Principles.Service;

// Open/Closed Principle: We can add new providers without modifying existing code
public enum WeatherProviderType {
    OpenWeatherMap, 
    AccuWeather, 
    // We can easily add more providers in the future (Here examples are AccuWeather and OpenWeatherMap)
    BKC_Clouds,
    WeatherStack
}
