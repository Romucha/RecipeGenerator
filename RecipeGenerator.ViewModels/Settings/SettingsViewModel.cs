using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Localization.Services;
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
        public DynamicLocalizationService DynamicLocalizationService { get; set; }

        public SettingsViewModel(ILogger<SettingsViewModel> logger, DynamicLocalizationService dynamicLocalizationService)
        {
            this.logger = logger;
            this.DynamicLocalizationService = dynamicLocalizationService;
        }

        public async Task InitializeAsync()
        {
            try
            {
                logger.LogInformation($"Initializing {nameof(SettingsViewModel)}...");
                await Task.CompletedTask;
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
    }
}
