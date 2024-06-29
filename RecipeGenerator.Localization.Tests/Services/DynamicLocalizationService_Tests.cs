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
        private readonly ILogger<DynamicLocalizationService> logger;

        public DynamicLocalizationService_Tests()
        {
            logger = new NullLogger<DynamicLocalizationService>();
        }

        [Theory]
        [InlineData(null, null, "en", new[] { "en", "ru" })]
        [InlineData("", new[] { "en", "ru", "fr" }, "en", new[] { "en", "ru" })]
        [InlineData(null, new[] { "en", "ru", "fr" }, "en", new[] { "en", "ru" })]
        [InlineData("en", new string[] { }, "en", new[] { "en", "ru" })]
        [InlineData("en", null, "en", new[] { "en", "ru" })]
        [InlineData("fr", new string[] { "en", "ru", "fr" }, "fr", new[] { "en", "ru", "fr" })]
        public void Constructor_Normal(string? currenCulture, IEnumerable<string>? cultures, string expectedCurrentCulture, IEnumerable<string> expectedCultures) 
        {
            //arrange
            DynamicLocalizationOptions options = new()
            {
                CurrentCulture = currenCulture,
                Cultures = cultures,
            };

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(expectedCurrentCulture, service.CurrentCulture);
            Assert.Equal(expectedCultures.Select(c => new CultureInfo(c)), service.Cultures);
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
            DynamicLocalizationService service = new(logger, options);
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
            DynamicLocalizationService service = new(logger, options);
            //act & assert
            service.SetCulture(currentCulture!);

            Assert.Equal(options.CurrentCulture, service.CurrentCulture);
        }
    }
}
