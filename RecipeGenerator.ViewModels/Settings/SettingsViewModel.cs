using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Localization.Services;

namespace RecipeGenerator.ViewModels.Settings
{
    public class SettingsViewModel : ObservableObject
    {
        private readonly ILogger<SettingsViewModel> logger;
        private readonly RecipeGeneratorDbContext dbContext;

        public DynamicLocalizationService DynamicLocalizationService { get; set; }

        public SettingsViewModel(ILogger<SettingsViewModel> logger, DynamicLocalizationService dynamicLocalizationService, RecipeGeneratorDbContext dbContext)
        {
            this.logger = logger;
            this.DynamicLocalizationService = dynamicLocalizationService;
            this.dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            try
            {
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(InitializeAsync));
                throw;
            }
        }

        public async Task ChangeCultureAsync(string culture)
        {
            try
            {
                DynamicLocalizationService.SetCulture(culture);
                dbContext.ChangeDatabase(culture);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(ChangeCultureAsync));
                throw;
            }
        }
    }
}
