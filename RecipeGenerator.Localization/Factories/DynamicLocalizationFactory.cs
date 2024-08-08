using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Factories
{
    public class DynamicLocalizationServiceFactory
    {
        private readonly ILogger<DynamicLocalizationServiceFactory> logger;
        private readonly ILoggerFactory loggerFactory;
        private readonly IOptions<DynamicLocalizationOptions> options;
        private readonly RecipeGeneratorValidator validator;

        public DynamicLocalizationServiceFactory(ILoggerFactory loggerFactory, IOptions<DynamicLocalizationOptions> options, RecipeGeneratorValidator validator) 
        {
            this.loggerFactory = loggerFactory;
            logger = this.loggerFactory.CreateLogger<DynamicLocalizationServiceFactory>();
            this.options = options;
            this.validator = validator;
        }

        public async Task<DynamicLocalizationService?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Cerating dynamic localization service...");
                var serviceLogger = loggerFactory.CreateLogger<DynamicLocalizationService>();
                var localizationOptions = await validator.ValidateAsync(options.Value);
                return await Task.FromResult(new DynamicLocalizationService(serviceLogger, localizationOptions));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                return await Task.FromResult<DynamicLocalizationService>(null);
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
