
using _03_SOLID_Principles.Model;

namespace _03_SOLID_Principles.Service;

public class OpenWeatherMapProvider : IWeatherProvider {
    public async System.Threading.Tasks.Task<WeatherData> GetWeatherForLocationAsync(string l) {
        await System.Threading.Tasks.Task.Delay(1000); // Simulate network delay

        return new WeatherData {
            Location = l,
            Temperature = 22,
            Condition = "Sunny (OpenWeatherMap demo)"
        };
    }
}