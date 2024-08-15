using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Ingredients;

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
