using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Platform;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Functionalities.Extensions;
using RecipeGenerator.Localization.Extensions;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Settings;
using RecipeGenerator.Utility.Extensions;
using RecipeGenerator.ViewModels;
using RecipeGenerator.ViewModels.Extensions;
using RecipeGenerator.ViewModels.Services;
using RecipeGenerator.Views;
using System;
using System.IO;
using System.Text.Json;

namespace RecipeGenerator
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; } = default!;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            BuildServices();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void BuildServices()
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddTransient<MainViewModel>();

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

            serviceCollection.AddRecipeGeneratorLocalization(config);
            serviceCollection.AddRecipeGeneratorUtility();
            serviceCollection.AddRecipeGeneratorFunctionality();
            serviceCollection.AddRecipeGeneratorViewModels();
            //serviceCollection.AddRecipeGeneratorDatabase(config);
            //serviceCollection.AddTransient<IMediaProviderService, MediaProviderService>();
            //serviceCollection.AddTransient<IFileSaverService, FileSaverService>();

            Services = serviceCollection.BuildServiceProvider();
        }
    }
}