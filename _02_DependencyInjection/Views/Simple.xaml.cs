using _02_DependencyInjection.Service;

namespace _02_DependencyInjection.Views;

public partial class Simple : ContentPage
{
	private readonly ITimeService _timeService;
	private readonly IWeatherService _weatherService;

	// Constructor with dependency injection
	public Simple(ITimeService timeService, IWeatherService weatherService)
	{
		InitializeComponent();

        _timeService = timeService;
        _weatherService = weatherService;

        // Show initial date/time
        UpdateDateTime();

        // Load initial weather data
        _ = LoadWeatherDataAsync();     // Explicitly discard the task
    }

	private void UpdateDateTime() {
		DateTimeLabel.Text = _timeService.GetCurrentTime();
	}

	private async Task LoadWeatherDataAsync() {
        try {
            var weather = await _weatherService.GetWeatherForecastAsync();

            TemperatureLabel.Text = weather.Temperature;
            WeatherConditionLabel.Text = weather.Condition;
            LocationLabel.Text = weather.Location;
        } catch (Exception ex) {
            await DisplayAlert("Error", $"Failed to load weather data: {ex.Message}", "OK");
        }
    }

    private async void OnRefreshClicked(object sender, EventArgs e) {
        RefreshButton.IsEnabled = false;

        UpdateDateTime();
        await LoadWeatherDataAsync();

        RefreshButton.IsEnabled = true;
    }
}