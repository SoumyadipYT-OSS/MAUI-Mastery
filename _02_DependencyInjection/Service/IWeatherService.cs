
namespace _02_DependencyInjection.Service;

public interface IWeatherService {
    System.Threading.Tasks.Task<WeatherData> GetWeatherForecastAsync();
}

public class WeatherData {
    public string? Temperature { get; set; }
    public string? Condition { get; set; }
    public string? Location { get; set; }
}