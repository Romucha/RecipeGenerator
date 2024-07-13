using Microsoft.Extensions.Logging;
using RecipeGenerator.Localization.Factories;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Services
{
    public class DynamicLocalizationService
    {
        private readonly ILogger<DynamicLocalizationService> logger;
        private readonly DynamicLocalizationFactory factory;

        public DynamicLocalizationService(ILogger<DynamicLocalizationService> logger, DynamicLocalizationFactory factory)
        {
            this.logger = logger;
            this.factory = factory;
        }

        private DynamicLocalization? dynamicLocalizationService = default!;

        public async Task<DynamicLocalization?> GetServiceAsync()
        {
            if (dynamicLocalizationService is null)
            {
                dynamicLocalizationService = await factory.CreateAsync();
            }

            return dynamicLocalizationService;

        }
    }
}
