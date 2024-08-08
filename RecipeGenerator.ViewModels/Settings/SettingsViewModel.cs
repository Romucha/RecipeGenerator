using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Settings
{
    public class SettingsViewModel : ObservableObject
    {
        private readonly ILogger<SettingsViewModel> logger;
        private readonly DynamicLocalizationServiceProvider dynamicLocalizationServiceProvider;
        private DynamicLocalizationService? dynamicLocalizationService;

        public SettingsViewModel(ILogger<SettingsViewModel> logger, DynamicLocalizationServiceProvider dynamicLocalizationServiceProvider)
        {
            this.logger = logger;
            this.dynamicLocalizationServiceProvider = dynamicLocalizationServiceProvider;
            dynamicLocalizationService = default!;
        }

        private ObservableCollection<string> cultures = new();
        public ObservableCollection<string> Cultures
        {
            get => cultures;
            set => SetProperty(ref cultures, value);
        }

        private string currentCulture;
        public string CurrentCulture
        {
            get => currentCulture;
            set => SetProperty(ref currentCulture, value);
        }

        public async Task InitializeAsync()
        {
            try
            {
                logger.LogInformation($"Initializing {nameof(SettingsViewModel)}...");
                dynamicLocalizationService = await dynamicLocalizationServiceProvider.GetServiceAsync();
                if (dynamicLocalizationService != null)
                {
                    Cultures = new(dynamicLocalizationService.Cultures.Select(c => c.Name));
                    CurrentCulture = dynamicLocalizationService.CurrentCulture;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(InitializeAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task ChangeCultureAsync()
        {
            try
            {
                logger.LogInformation("Changing culture...");
                if (dynamicLocalizationService != null)
                {
                    dynamicLocalizationService.SetCulture(CurrentCulture);
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(ChangeCultureAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
