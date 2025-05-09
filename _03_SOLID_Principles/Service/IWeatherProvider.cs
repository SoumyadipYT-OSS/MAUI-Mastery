using _03_SOLID_Principles.Model;

namespace _03_SOLID_Principles.Service;

public interface IWeatherProvider {
    System.Threading.Tasks.Task<WeatherData> GetWeatherForLocationAsync(string location);
}

