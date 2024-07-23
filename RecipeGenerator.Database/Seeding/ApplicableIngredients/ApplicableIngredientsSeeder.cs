using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Resources.Identifiers.Ingredients;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Seeding.ApplicableIngredients
{
    public class ApplicableIngredientsSeeder : BaseSeeder<ApplicableIngredient>
    {
        private readonly ILogger<ApplicableIngredientsSeeder> logger;

        public ApplicableIngredientsSeeder(ILogger<ApplicableIngredientsSeeder> logger)
        {
            this.logger = logger;
        }

        public override async Task<IEnumerable<ApplicableIngredient>> GetEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation("Creating list of inredients...");
                    ResourceManager resourceManager = new ResourceManager(typeof(Identifiers_Ingredients)); 
                    ResourceSet? resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                    return Enumerable.Empty<ApplicableIngredient>();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(GetEntitiesAsync));
                    return Enumerable.Empty<ApplicableIngredient>();
                }
                finally
                {
                    logger.LogInformation("Done.");
                }
            }, cancellationToken);
        }
    }
}
