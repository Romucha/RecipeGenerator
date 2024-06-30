using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class RecipeGeneratorValidator
    {
        private readonly ILogger<RecipeGeneratorValidator> logger;

        public RecipeGeneratorValidator(ILogger<RecipeGeneratorValidator> logger)
        {
            this.logger = logger;
        }

        public async Task<T?> ValidateAsync<T>(T value)
        {
            try
            {
                logger.LogInformation("Validating...");
                if (value is null)
                {
                    logger.LogError("Value was null.");
                    return await Task.FromResult<T?>(default);
                }
                ValidationContext validationContext = new(value);
                List<ValidationResult> results = new();

                if (Validator.TryValidateObject(value, validationContext, results, true))
                {
                    return await Task.FromResult(value);
                }
                else
                {
                    logger.LogError(string.Join("\r\n", results.Select(c => c.ErrorMessage)));
                    return await Task.FromResult<T?>(default);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(ValidateAsync));
                return await Task.FromResult<T?>(default);
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
