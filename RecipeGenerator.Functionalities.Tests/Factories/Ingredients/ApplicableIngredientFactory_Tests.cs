using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Ingredients;

namespace RecipeGenerator.Functionalities.Tests.Factories.Ingredients
{
    public class ApplicableIngredientFactory_Tests
    {
        private readonly ILogger<ApplicableIngredientFactory> logger;

        public ApplicableIngredientFactory_Tests()
        {
            logger = new NullLogger<ApplicableIngredientFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ApplicableIngredientFactory factory = new(logger);
            //act
            var result = await factory.CreateAsync();
            //assert
            Assert.NotNull(result);
        }
    }
}
