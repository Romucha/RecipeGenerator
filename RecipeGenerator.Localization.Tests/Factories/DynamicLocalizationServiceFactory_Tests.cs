using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Factories;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
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
        public DynamicLocalizationServiceFactory_Tests()
        {
            
        }

        [Fact]
        public async Task Create_Normal()
        {
            //arrange
            var loggerFactory = new NullLoggerFactory();
            var options = Options.Create(new DynamicLocalizationOptions()
            {
                CurrentCulture = "en",
                Cultures =
                [
                    "en",
                    "ru"
                ]
            });
            DynamicLocalizationFactory factory = new DynamicLocalizationFactory(loggerFactory, options);
            //act
            DynamicLocalizationService? service = await factory.CreateAsync();
            //assert
            Assert.NotNull(service);
            Assert.Equal(options.Value.CurrentCulture, service.CurrentCulture);
            Assert.Equal(options.Value.Cultures!.Select(c => new CultureInfo(c)), service.Cultures);
        }
    }
}
