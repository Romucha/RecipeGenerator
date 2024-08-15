using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Ingredients;

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
