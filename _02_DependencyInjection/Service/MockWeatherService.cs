
namespace _02_DependencyInjection.Service;

public class MockWeatherService : IWeatherService {
    private readonly Random _random = new();
    private readonly string[] _conditions = ["Sunny", "Cloudy", "Rainy", "Snowy"];
    private readonly string[] _locations = ["Mizoram", "Kolkata", "Bhubaneshwar", "Assam"];

    public System.Threading.Tasks.Task<WeatherData> GetWeatherForecastAsync() {
        return System.Threading.Tasks.Task.FromResult(new WeatherData {
            Temperature = $"{_random.Next(50, 90)}°F",
            Condition = _conditions[_random.Next(_conditions.Length)],
            Location = _locations[_random.Next(_locations.Length)]
        });
    }
}