using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Resources.Extensions;
using System.Reflection;

namespace RecipeGenerator
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
            builder.Services.AddRecipeGeneratorResources(builder.Configuration);
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("RecipeGenerator.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();


                builder.Configuration.AddConfiguration(config);
            }

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
