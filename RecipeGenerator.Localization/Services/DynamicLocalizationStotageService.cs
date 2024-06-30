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
    public class DynamicLocalizationStotageService
    {
        private readonly ILogger<DynamicLocalizationStotageService> logger;
        private readonly DynamicLocalizationFactory factory;

        public DynamicLocalizationStotageService(ILogger<DynamicLocalizationStotageService> logger, DynamicLocalizationFactory factory)
        {
            this.logger = logger;
            this.factory = factory;
        }

        private DynamicLocalizationService dynamicLocalizationService = default!;

        public async Task<DynamicLocalizationService> GetServiceAsync()
        {
            if (dynamicLocalizationService is null)
            {
                dynamicLocalizationService = await factory.CreateAsync()!;
            }

            return dynamicLocalizationService;

        }
    }
}
