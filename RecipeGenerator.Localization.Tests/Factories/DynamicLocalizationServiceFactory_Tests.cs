using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Factories;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Tests.Factories
{
    public class DynamicLocalizationServiceFactory_Tests
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly RecipeGeneratorValidator validator;

        public DynamicLocalizationServiceFactory_Tests()
        {
            loggerFactory = new NullLoggerFactory();
            validator = new RecipeGeneratorValidator(loggerFactory.CreateLogger<RecipeGeneratorValidator>());
        }

        [Fact]
        public async Task Create_Normal()
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
            //act
            DynamicLocalizationService? service = await factory.CreateAsync()!;
            //assert
            Assert.NotNull(service);
            Assert.Equal(localizationOptions.CurrentCulture, service.CurrentCulture);
            Assert.Equal(localizationOptions.Cultures.Select(c => new CultureInfo(c)), service.Cultures);
        }

        [Theory]
        [InlineData("", new[] { "en", "ru", "fr" })]
        [InlineData(null, new[] { "en", "ru", "fr" })]
        [InlineData("fr", new string[] { })]
        [InlineData("fr", null)]
        [InlineData(null, null)]
        public async Task Create_ReturnsDefault_WhenOptionsAreInvalid(string? currentCulture, string[]? cultures)
        {
            //arrange
            var localizationOptions = new DynamicLocalizationOptions()
            {
                CurrentCulture = currentCulture,
                Cultures = cultures
            };
            var expectedOptions = DynamicLocalizationOptions.DefaultLocalizationOptions;
            var options = Options.Create(localizationOptions);
            DynamicLocalizationServiceFactory factory = new DynamicLocalizationServiceFactory(loggerFactory, options, validator);

            //act
            DynamicLocalizationService? service = await factory.CreateAsync()!;

            //assert
            Assert.Null(service);
        }
    }
}
