using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Settings
{
    public class SettingsViewModel : ObservableObject
    {
        private readonly ILogger<SettingsViewModel> logger;
        private readonly DynamicLocalizationServiceProvider dynamicLocalizationService;
        private DynamicLocalizationService? dynamicLocalization;

        public SettingsViewModel(ILogger<SettingsViewModel> logger, DynamicLocalizationServiceProvider dynamicLocalizationService)
        {
            this.logger = logger;
            this.dynamicLocalizationService = dynamicLocalizationService;
            dynamicLocalization = default!;
        }

        public async Task InitializeAsync()
        {
            try
            {
                logger.LogInformation($"Initializing {nameof(SettingsViewModel)}...");
                dynamicLocalization = await dynamicLocalizationService.GetServiceAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(InitializeAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
