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
        public DynamicLocalizationService? DynamicLocalizationService;

        public SettingsViewModel(ILogger<SettingsViewModel> logger, DynamicLocalizationServiceProvider dynamicLocalizationServiceProvider)
        {
            this.logger = logger;
            this.dynamicLocalizationServiceProvider = dynamicLocalizationServiceProvider;
            DynamicLocalizationService = default!;
        }

        public async Task InitializeAsync()
        {
            try
            {
                logger.LogInformation($"Initializing {nameof(SettingsViewModel)}...");
                DynamicLocalizationService = await dynamicLocalizationServiceProvider.GetServiceAsync();
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

        public async Task ChangeCultureAsync(string currentCulture)
        {
            try
            {
                logger.LogInformation("Changing culture...");
                if (DynamicLocalizationService != null)
                {
                    DynamicLocalizationService.SetCulture(currentCulture);
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
