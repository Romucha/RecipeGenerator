using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Factories.Steps
{
    public class StepFactory
    {
        private readonly ILogger<StepFactory> logger;

        public StepFactory(ILogger<StepFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<Step?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Creating new step...");
                return await Task.FromResult(new Step()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
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
