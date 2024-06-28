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

        [Fact]
        public void Constructor_Normal_NoOptions()
        {
            //arrange
            var currentCulture = "en";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new());

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }

        [Fact]
        public void Constructor_Culture_WithOptions() 
        {
            //arrange
            var currentCulture = "fr";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru"),
                new CultureInfo("fr")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = "fr",
                Cultures = [
                    "en",
                    "ru",
                    "fr"
                    ]
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }

        [Fact]
        public void Constructor_Culture_WithInvalidOptions_EmptyCurrentCulture()
        {
            //arrange
            var currentCulture = "en";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = "",
                Cultures = [
                    "en",
                    "ru",
                    "fr"
                    ]
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }

        [Fact]
        public void Constructor_Culture_WithInvalidOptions_NullCurrentCulture()
        {
            //arrange
            var currentCulture = "en";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = null,
                Cultures = [
                    "en",
                    "ru",
                    "fr"
                    ]
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }

        [Fact]
        public void Constructor_Culture_WithInvalidOptions_EmptyCultures()
        {
            //arrange
            var currentCulture = "en";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = "fr",
                Cultures = [
                    ]
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }

        [Fact]
        public void Constructor_Culture_WithInvalidOptions_NullCultures()
        {
            //arrange
            var currentCulture = "en";
            var cultures = new ObservableCollection<CultureInfo>([
                new CultureInfo("en"),
                new CultureInfo("ru")
                ]);
            IOptions<DynamicLocalizationOptions> options = Options.Create<DynamicLocalizationOptions>(new()
            {
                CurrentCulture = "fr",
                Cultures = null
            });

            //act
            DynamicLocalizationService service = new(logger, options);

            //assert
            Assert.Equal(currentCulture, service.CurrentCulture);
            Assert.Equal(cultures, service.Cultures);
        }
    }
}
