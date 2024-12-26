using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Models;
using RecipeGenerator.Localization.Models.Models;
using RecipeGenerator.Localization.Services;

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
            DynamicLocalizationService service = new(logger, Options.Create(options), new ConfigurationFileWriterService(new NullLogger<ConfigurationFileWriterService>()));
            //act
            service.Initialize();
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
            DynamicLocalizationService service = new(
                logger, 
                Options.Create(options), 
                new ConfigurationFileWriterService(new NullLogger<ConfigurationFileWriterService>()));
            //act & assert
            service.Initialize();
            service.SetCulture(currentCulture!);

            Assert.Equal(options.CurrentCulture, service.CurrentCulture);
        }
    }
}
