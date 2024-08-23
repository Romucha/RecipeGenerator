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

        private bool inProgress = false;
        public bool InProgress
        {
            get => inProgress; 
            set => SetProperty(ref inProgress, value);
        }

        public MainViewModel(ApplicableIngredientsSeeder applicableIngredientsSeeder, IUnitOfWork unitOfWork, ILogger<MainViewModel> logger)
        {
            this.applicableIngredientsSeeder = applicableIngredientsSeeder;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task InitializeAsync()
        {
            try
            {
                InProgress = true;
                GetAllApplicableIngredientsResponse? getAllApplicableIngredientsResponse = await unitOfWork.ApplicableIngredientRepository.GetAllAsync(0, 0, null);
                if (getAllApplicableIngredientsResponse != null)
                {
                    if (getAllApplicableIngredientsResponse.TotalCount == 0)
                    {
                        var ingredients = await applicableIngredientsSeeder.GetEntitiesAsync();
                        ingredients.ToList().ForEach(async ent =>
                        {
                            await unitOfWork.ApplicableIngredientRepository.UpdateAsync(
                                ent.Id, 
                                ent.Name, 
                                ent.Description, 
                                ent.Link, 
                                (IngredientType)ent.IngredientType, 
                                ent.Image);
                        });
                        await unitOfWork.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(MainViewModel));
                throw;
            }
            finally
            {
                InProgress = false;
            }
        }
    }
}
