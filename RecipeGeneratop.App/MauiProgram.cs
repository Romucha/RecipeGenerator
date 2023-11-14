using Microsoft.AspNetCore.Components.WebView.Maui;
using RecipeGenerator.API;
using RecipeGenerator.API.Database;
using RecipeGenerator.App.Data;
using RecipeGenerator.App.ViewModels;

namespace RecipeGenerator.App
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
             });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddSingleton<MainVM>();

            builder.Services.AddDatabase();

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}