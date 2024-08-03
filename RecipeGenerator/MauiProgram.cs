using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Functionalities.Extensions;
using RecipeGenerator.Localization.Extensions;
using RecipeGenerator.Utility.Extensions;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.ViewModels.Extensions;
using System.Reflection;
using RecipeGenerator.ViewModels.Services;
using RecipeGenerator.Services;

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
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("RecipeGenerator.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();


                builder.Configuration.AddConfiguration(config);
            }

            builder.Services.AddRecipeGeneratorResources(builder.Configuration);
            builder.Services.AddRecipeGeneratorUtility();
            builder.Services.AddRecipeGeneratorFunctionality();
            builder.Services.AddRecipeGeneratorViewModels();
            builder.Services.AddRecipeGeneratorDatabase();
            builder.Services.AddTransient<IMediaProviderService, MediaProviderService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
