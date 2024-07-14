using AutoMapper;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RecipeGenerator.Functionalities.Factories.Ingredients
{
    public class ApplicableIngredientFactory
    {
        private readonly ILogger<ApplicableIngredientFactory> logger;

        public ApplicableIngredientFactory(ILogger<ApplicableIngredientFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<ApplicableIngredient?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Creating a new applicable ingredient...");
                return await Task.FromResult(new ApplicableIngredient()
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
