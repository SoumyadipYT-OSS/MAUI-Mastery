using Microsoft.Extensions.Logging;
using _03_SOLID_Principles.Service;
using _03_SOLID_Principles.Views;

namespace _03_SOLID_Principles
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register SOLID principles services
            builder.Services.AddSingleton<IWeatherProviderFactory, WeatherProviderFactory>();
            builder.Services.AddSingleton<IWeatherService, WeatherService>(sp => {
                var factory = sp.GetRequiredService<IWeatherProviderFactory>();
                var defaultProvider = factory.CreateProvider(WeatherProviderType.OpenWeatherMap);
                return new WeatherService(defaultProvider);
            });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
