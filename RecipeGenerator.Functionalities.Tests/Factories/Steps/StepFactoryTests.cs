using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Steps;
using RecipeGenerator.Models.Steps;

namespace RecipeGenerator.Functionalities.Tests.Factories.Steps
{
    public class StepFactoryTests
    {
        private readonly ILogger<StepFactory> logger;

        public StepFactoryTests()
        {
            logger = new NullLogger<StepFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            StepFactory factory = new(logger);
            //act
            var result = await factory.CreateAsync();
            //assert
            Assert.NotNull(result);
        }
    }
}
