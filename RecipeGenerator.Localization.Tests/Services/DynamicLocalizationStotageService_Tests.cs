using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Factories;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Tests.Services
{
    public class DynamicLocalizationStotageService_Tests
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<DynamicLocalizationServiceProvider> logger;
        private readonly RecipeGeneratorValidator validator;

        public DynamicLocalizationStotageService_Tests()
        {
            loggerFactory = new NullLoggerFactory();
            validator = new RecipeGeneratorValidator(loggerFactory.CreateLogger<RecipeGeneratorValidator>());
            logger = new NullLogger<DynamicLocalizationServiceProvider>();
        }

        [Fact]
        public async Task GetService_Normal()
        {
            //arrange
            var localizationOptions = new DynamicLocalizationOptions()
            {
                CurrentCulture = "fr",
                Cultures =
                [
                    "en",
                    "ru",
                    "fr"
                ]
            };
            var options = Options.Create(localizationOptions);
            DynamicLocalizationServiceFactory factory = new DynamicLocalizationServiceFactory(loggerFactory, options, validator);
            DynamicLocalizationServiceProvider stotageService = new DynamicLocalizationServiceProvider(logger, factory);
            //act
            var service = await stotageService.GetServiceAsync();

            //assert
            Assert.NotNull(service);
            Assert.Equal(localizationOptions.CurrentCulture, service.CurrentCulture);
            Assert.Equal(localizationOptions.Cultures.Select(c => new CultureInfo(c)), service.Cultures);
        }

        [Fact]
        public async Task GetService_ReturnsNull()
        {
            //arrange
            DynamicLocalizationOptions localizationOptions = null;
            var options = Options.Create(localizationOptions);
            DynamicLocalizationServiceFactory factory = new DynamicLocalizationServiceFactory(loggerFactory, options, validator);
            DynamicLocalizationServiceProvider stotageService = new DynamicLocalizationServiceProvider(logger, factory);
            //act
            var service = await stotageService.GetServiceAsync();

            //assert
            Assert.Null(service);
        }
    }
}
