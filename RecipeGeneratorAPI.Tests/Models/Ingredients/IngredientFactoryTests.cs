using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGeneratorAPI.Tests.Models.Ingredients
{
    public class IngredientFactoryTests
    {
        [Fact]
        public void Create_Normal()
        {
            //arrange
            IIngredientFactory ingredientFactory = new IngredientFactory();
            string name = "Name";
            string description = "Description";
            Uri link = new Uri("http://uri.uri");
            byte[] image = new byte[] { };
            IngredientType ingredientType = IngredientType.Fruits;
            //act
            var ingredient = ingredientFactory.Create(name, description, link, image, ingredientType);
            //assert
            Assert.NotNull(ingredient);
            Assert.Equal(name, ingredient.Name);
            Assert.Equal(description, ingredient.Description);
            Assert.Equal(link, ingredient.Link);
            Assert.Equal(image, ingredient.Image);
            Assert.Equal(ingredientType, ingredient.IngredientType);
        }
    }
}
