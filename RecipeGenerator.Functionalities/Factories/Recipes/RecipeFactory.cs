using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Factories.Recipes
{
    public class RecipeFactory
    {
        private readonly ILogger<RecipeFactory> logger;

        public RecipeFactory(ILogger<RecipeFactory> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Creates default instance of <see cref="Recipe"/> class.
        /// </summary>
        /// <returns></returns>
        public async Task<Recipe?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Creating new recipe...");

                return await Task.FromResult(new Recipe()
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
