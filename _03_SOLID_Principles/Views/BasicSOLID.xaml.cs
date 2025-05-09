using System.ComponentModel;
using System.Runtime.CompilerServices;
using _03_SOLID_Principles.Model;
using _03_SOLID_Principles.Service;

namespace _03_SOLID_Principles.Views;

public partial class BasicSOLID : ContentPage
{
    // Dependency Inversion Principle: Depending on abstraction
    private readonly IWeatherService _weatherService;
    private readonly IWeatherProviderFactory _providerFactory;
    private WeatherProviderType _currentProviderType = WeatherProviderType.OpenWeatherMap;

    public BasicSOLID()
	{
		InitializeComponent();

        // Setup service dependencies
        _providerFactory = new WeatherProviderFactory();

        // Initial weather provider configuration
        IWeatherProvider provider = _providerFactory.CreateProvider(_currentProviderType);
        _weatherService = new WeatherService(provider);
    }


    private async void OnLoadWeatherClicked(object sender, EventArgs e) {
        try {
            LoadWeatherButton.IsEnabled = false;
            LoadWeatherButton.Text = "Loading...";

            // Demonstrates the service in action
            WeatherData weatherData = await _weatherService.GetCurrentWeatherAsync("New York");

            // Update UI with weather data
            LocationLabel.Text = $"Location: {weatherData.Location}";
            TemperatureLabel.Text = $"Temperature: {weatherData.Temperature}°C";
            ConditionLabel.Text = $"Condition: {weatherData.Condition}";
        } catch (Exception ex) {
            await DisplayAlert("Error", $"Could not load weather: {ex.Message}", "OK");
        } finally {
            LoadWeatherButton.IsEnabled = true;
            LoadWeatherButton.Text = "Load Weather";
        }
    }

    private void OnSwitchProviderClicked(object sender, EventArgs e) {
        // Switch between weather providers to demonstrate Liskov Substitution
        _currentProviderType = _currentProviderType == WeatherProviderType.OpenWeatherMap
            ? WeatherProviderType.AccuWeather
            : WeatherProviderType.OpenWeatherMap;

        // Get a new provider and update the service
        IWeatherProvider newProvider = _providerFactory.CreateProvider(_currentProviderType);
        _weatherService.SetWeatherProvider(newProvider);

        SwitchProviderButton.Text = $"Using: {_currentProviderType}";
    }
}