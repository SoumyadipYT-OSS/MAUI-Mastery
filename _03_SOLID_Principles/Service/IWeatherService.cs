using _03_SOLID_Principles.Model;

namespace _03_SOLID_Principles.Service;

public interface IWeatherService {
    System.Threading.Tasks.Task<WeatherData> GetCurrentWeatherAsync(string l);
    void SetWeatherProvider(IWeatherProvider provider);
}
