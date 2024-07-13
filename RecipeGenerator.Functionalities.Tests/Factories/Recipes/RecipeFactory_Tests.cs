using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Functionalities.Factories.Recipes;
using RecipeGenerator.Functionalities.Factories.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Tests.Factories.Recipes
{
    public class RecipeFactory_Tests
    {
        private readonly ILogger<RecipeFactory> logger;

        public RecipeFactory_Tests()
        {
            logger = new NullLogger<RecipeFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            RecipeFactory factory = new(logger);
            //act
            var result = await factory.CreateAsync();
            //assert
            Assert.NotNull(result);
        }
    }
}
