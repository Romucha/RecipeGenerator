using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Localization.Tests.Services
{
    public class DynamicLocalizationService_Tests
    {
        private readonly ILogger<DynamicLocalization> logger;

        public DynamicLocalizationService_Tests()
        {
            logger = new NullLogger<DynamicLocalization>();
        }

        [Fact]
        public void SetCulture_Normal()
        {
            //arrange
            DynamicLocalizationOptions options = new()
            {
                CurrentCulture = "en",
                Cultures =
                [
                    "en",
                    "ru",
                    "fr"
                ],
            };
            DynamicLocalization service = new(logger, options);
            //act
            service.SetCulture("ru");

            //assert
            Assert.Equal("ru", service.CurrentCulture);
        }

        [Theory]
        [InlineData("de")]
        [InlineData("")]
        [InlineData(null)]
        public void SetCulture_DoesNotChangeCulture_WhenInputIsInvalid(string? currentCulture)
        {
            //arrange
            DynamicLocalizationOptions options = new()
            {
                CurrentCulture = "en",
                Cultures =
                [
                    "en",
                    "ru",
                    "fr"
                ],
            };
            DynamicLocalization service = new(logger, options);
            //act & assert
            service.SetCulture(currentCulture!);

            Assert.Equal(options.CurrentCulture, service.CurrentCulture);
        }
    }
}
