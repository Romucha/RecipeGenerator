using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Steps;

namespace RecipeGenerator.Functionalities.Tests.Factories.Steps
{
    public class StepFactory_Tests
    {
        private readonly ILogger<StepFactory> logger;

        public StepFactory_Tests()
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
