using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Main
{
    public class MainViewModel : ObservableObject
    {
        private readonly ApplicableIngredientsSeeder applicableIngredientsSeeder;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<MainViewModel> logger;
        private readonly ProgressViewModel progressViewModel;

        public MainViewModel(ApplicableIngredientsSeeder applicableIngredientsSeeder, IUnitOfWork unitOfWork, ILogger<MainViewModel> logger, ProgressViewModel progressViewModel)
        {
            this.applicableIngredientsSeeder = applicableIngredientsSeeder;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.progressViewModel = progressViewModel;
        }

        public async Task InitializeAsync()
        {
            try
            {
                progressViewModel.InProgress = true;
                await applicableIngredientsSeeder.SeedDatabaseAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(MainViewModel));
                throw;
            }
            finally
            {
                progressViewModel.InProgress = false;
            }
        }
    }
}
