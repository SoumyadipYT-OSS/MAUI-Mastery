
using _03_SOLID_Principles.Model;

namespace _03_SOLID_Principles.Service;

public class AccuWeatherProvider : IWeatherProvider {
    public async System.Threading.Tasks.Task<WeatherData> GetWeatherForLocationAsync(string l) {
        await System.Threading.Tasks.Task.Delay(1000); // Simulate network delay

        return new WeatherData {
            Location = l,
            Temperature = 25.0,
            Condition = "Partly Cloudy (AccuWeather demo)"
        };
    }
}
