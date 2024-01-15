using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Database.Ingredients
{
    public partial class IngredientRepository_Tests
    {
        [Fact]
        public async Task GetAll_Normal()
        {
            //arrange

            //act
            var recipes = await ingredientRepository.GetAll();
            //assert
            Assert.NotNull(recipes);
            Assert.NotEmpty(recipes);
        }
    }
}
