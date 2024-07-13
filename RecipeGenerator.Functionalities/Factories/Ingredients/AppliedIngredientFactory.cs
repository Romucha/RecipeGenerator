using AutoMapper;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.DTO.AppliedIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RecipeGenerator.Functionalities.Factories.Ingredients
{
    public class AppliedIngredientFactory
    {
        private readonly ILogger<AppliedIngredientFactory> logger;

        public AppliedIngredientFactory(ILogger<AppliedIngredientFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<AppliedIngredient?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Creating a new applied ingredient...");
                return await Task.FromResult(new AppliedIngredient()
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
