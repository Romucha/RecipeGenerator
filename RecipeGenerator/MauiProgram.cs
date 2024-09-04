using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Functionalities.Extensions;
using RecipeGenerator.Localization.Extensions;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Services;
using RecipeGenerator.Settings;
using RecipeGenerator.Utility.Extensions;
using RecipeGenerator.ViewModels.Extensions;
using RecipeGenerator.ViewModels.Services;
using System.Reflection;
using System.Text.Json;

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

            var configFile = ConfigurationFileWriterService.FilePath;

            if (!Directory.Exists(Path.GetDirectoryName(configFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configFile)!);
            }

            if (!File.Exists(configFile))
            {
                File.WriteAllText(configFile, JsonSerializer.Serialize(DefaultAppSettings.Instance));
            }

            var config = new ConfigurationBuilder()
                    .AddJsonFile(configFile)
                    .Build();

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddRecipeGeneratorLocalization(builder.Configuration);
            builder.Services.AddRecipeGeneratorUtility();
            builder.Services.AddRecipeGeneratorFunctionality();
            builder.Services.AddRecipeGeneratorViewModels();
            builder.Services.AddRecipeGeneratorDatabase(builder.Configuration);
            builder.Services.AddTransient<IMediaProviderService, MediaProviderService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Logging.AddNLog();

            string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RecipeGenerator", "Logs", "recipe-log.log");
            //Configure Nlog in a Fluent API way
            NLog.LogManager.Setup().LoadConfiguration(builder =>
            {
                builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToConsole();
                builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToFile(
                    fileName: logFilePath,
                    encoding: System.Text.Encoding.UTF8,
                    archiveAboveSize: 100 * 1024,
                    maxArchiveFiles: 10);
            });

            return builder.Build();
        }
    }
}
