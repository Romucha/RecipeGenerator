using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Ingredients;
using RecipeGenerator.Functionalities.Factories.Recipes;
using RecipeGenerator.Functionalities.Factories.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
