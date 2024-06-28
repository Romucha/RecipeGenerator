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
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = currenCulture,
                Cultures = cultures,
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(expectedCurrentCulture, service.CurrentCulture);
            Assert.Equal(expectedCultures.Select(c => new CultureInfo(c)), service.Cultures);
        }
    }
}
