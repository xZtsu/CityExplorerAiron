using CityExplorerAiron.Services;
using CityExplorerAiron.ViewModels;
using CityExplorerAiron.Views;
using Microsoft.Extensions.Logging;

namespace CityExplorerAiron
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            // Registreeri teenused
            builder.Services.AddSingleton<DatabaseService>();

            // Registreeri vaatemudelid
            builder.Services.AddTransient<BaseViewModel>();
            builder.Services.AddTransient<ExploreViewModel>();
            builder.Services.AddTransient<FavoritesViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Registreeri vaated
            builder.Services.AddTransient<ExplorePage>();
            builder.Services.AddTransient<FavoritesPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<Views.MainTabbedPage>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.UseMauiApp<App>();




            return builder.Build();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
