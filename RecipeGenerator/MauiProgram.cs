//using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using RecipeGenerator.Database.Extenstions;
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
             //.UseMauiCommunityToolkit()
             .ConfigureFonts(fonts =>
             {
                 fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                 fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
             }); ;

            builder.Services.AddMauiBlazorWebView();

            var configFile = ConfigurationFileWriterService.FilePath;

            if (!Directory.Exists(Path.GetDirectoryName(configFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configFile)!);
            }

            if (!File.Exists(configFile))
            {
                File.WriteAllText(configFile, JsonSerializer.Serialize(AppSettings.Default));
            }

            var config = new ConfigurationBuilder()
                    .AddJsonFile(configFile)
                    .Build();

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddRecipeGeneratorLocalization(builder.Configuration);
            builder.Services.AddRecipeGeneratorUtility();
            builder.Services.AddRecipeGeneratorViewModels();
            builder.Services.AddRecipeGeneratorDatabase(builder.Configuration);
            builder.Services.AddTransient<IMediaProviderService, MediaProviderService>();
            builder.Services.AddTransient<IFileSaverService, FileSaverService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Logging.AddNLog();

            LogManager.Setup().LoadConfiguration(builder =>
            {
                builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToConsole();
                builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToFile(
                    fileName: Path.Combine(AppPaths.LogFolder, $"recipe-log_{DateTime.UtcNow:yyyy-MM-dd}.log"),
                    encoding: System.Text.Encoding.UTF8,
                    archiveAboveSize: 100 * 1024,
                    maxArchiveFiles: 10);
            });

            return builder.Build();
        }
    }
}
