using _03_SOLID_Principles.Model;

namespace _03_SOLID_Principles.Service;

public class WeatherService : IWeatherService {
    private IWeatherProvider _weatherProvider;
    public WeatherService(IWeatherProvider weatherProvider) {
        _weatherProvider = weatherProvider;
    }
    public void SetWeatherProvider(IWeatherProvider provider) {
        _weatherProvider = provider;
    }
    public async Task<WeatherData> GetCurrentWeatherAsync(string location) {
        // Validate input
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be empty");

        // Delegate to the configured provider
        return await _weatherProvider.GetWeatherForLocationAsync(location);
    }
}
