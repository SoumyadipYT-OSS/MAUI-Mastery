using Microsoft.Extensions.Logging;
using _02_DependencyInjection.Service;
using _02_DependencyInjection.Views;

namespace _02_DependencyInjection
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


            // Register services
            builder.Services.AddSingleton<IGreetingService, GreetingService>();
            builder.Services.AddTransient<Basic>();
            builder.Services.AddSingleton<ITimeService, ServiceTime>();
            builder.Services.AddTransient<IWeatherService, MockWeatherService>();
            builder.Services.AddTransient<Simple>();
            builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
            builder.Services.AddTransient<Custom>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
