using AutoMapper;
using Moq;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Models.Ingredients
{
    public class IngredientFactoryTests
    {
        [Fact]
        public void Create_Normal()
        {
            //arrange
            IMapper mapper = new Mock<IMapper>(new MapperConfiguration(c => c.AddProfile(new MapperInitializer()))).Object;
            IIngredientFactory ingredientFactory = new IngredientFactory(mapper);
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
