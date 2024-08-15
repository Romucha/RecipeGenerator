using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Ingredients;

namespace RecipeGenerator.Functionalities.Tests.Factories.Ingredients
{
    public class AppliedIngredientFactory_Tests
    {
        private readonly ILogger<AppliedIngredientFactory> logger;

        public AppliedIngredientFactory_Tests()
        {
            logger = new NullLogger<AppliedIngredientFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            AppliedIngredientFactory factory = new(logger);
            //act
            var result = await factory.CreateAsync();
            //assert
            Assert.NotNull(result);
        }
    }
}
