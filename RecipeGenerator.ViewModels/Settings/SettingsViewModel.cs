using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Main;

namespace RecipeGenerator.ViewModels.Settings
{
    public class SettingsViewModel : ObservableObject
    {
        private readonly ILogger<SettingsViewModel> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly ApplicableIngredientsSeeder applicableIngredientsSeeder;
        private readonly ProgressViewModel progressViewModel;

        public DynamicLocalizationService DynamicLocalizationService { get; set; }

        public SettingsViewModel(
            ILogger<SettingsViewModel> logger, 
            DynamicLocalizationService dynamicLocalizationService, 
            RecipeGeneratorDbContext dbContext, 
            ApplicableIngredientsSeeder applicableIngredientsSeeder,
            ProgressViewModel progressViewModel)
        {
            this.logger = logger;
            this.DynamicLocalizationService = dynamicLocalizationService;
            this.dbContext = dbContext;
            this.applicableIngredientsSeeder = applicableIngredientsSeeder;
            this.progressViewModel = progressViewModel;
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
                progressViewModel.InProgress = true;
                DynamicLocalizationService.SetCulture(culture);
                dbContext.ChangeDatabase(culture);
                await applicableIngredientsSeeder.SeedDatabaseAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(ChangeCultureAsync));
                throw;
            }
            finally
            {
                progressViewModel.InProgress = false;
            }
        }
    }
}
