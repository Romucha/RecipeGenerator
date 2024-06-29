using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Factories
{
    public class DynamicLocalizationFactory
    {
        private readonly ILogger<DynamicLocalizationFactory> logger;
        private readonly ILoggerFactory loggerFactory;
        private readonly IOptions<DynamicLocalizationOptions> options;

        public DynamicLocalizationFactory(ILoggerFactory loggerFactory, IOptions<DynamicLocalizationOptions> options) 
        {
            this.loggerFactory = loggerFactory;
            logger = this.loggerFactory.CreateLogger<DynamicLocalizationFactory>();
            this.options = options;
        }

        public async Task<DynamicLocalizationService>? CreateAsync()
        {
            try
            {
                logger.LogInformation("Cerating dynamic localization service...");
                ValidationContext validationContext = new ValidationContext(options.Value);
                var results = new List<ValidationResult>();
                var serviceLogger = loggerFactory.CreateLogger<DynamicLocalizationService>();
                if (Validator.TryValidateObject(options.Value, validationContext, results, true))
                {
                    return await Task.FromResult(new DynamicLocalizationService(serviceLogger, options.Value));
                }
                else
                {
                    logger.LogInformation(string.Join("\r\n", results.Select(c => c.ErrorMessage)));
                    return await Task.FromResult(new DynamicLocalizationService(serviceLogger, DynamicLocalizationOptions.DefaultLocalizationOptions));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                return await Task.FromResult<DynamicLocalizationService>(null!);
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
