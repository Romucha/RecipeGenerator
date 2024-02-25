using AutoMapper;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Database.Ingredients
{
    public class IngredientGetter_Tests
    {
        private readonly IIngredientGetter ingredientGetter;
        public IngredientGetter_Tests()
        {
            var config = new MapperConfiguration(c => c.AddProfile(new MapperInitializer()));
            IMapper mapper = config.CreateMapper();
            IIngredientFactory ingredientFactory = new IngredientFactory(mapper);
            ingredientGetter = new IngredientGetter(ingredientFactory);
        }

        [Fact]
        public void Get_Normal()
        {
            //arrange

            //act
            var ingredients = ingredientGetter.Get();
            //assert
            Assert.NotNull(ingredients);
            Assert.NotEmpty(ingredients);
            Assert.Contains(ingredients, c => string.IsNullOrEmpty(c.Name));
        }
    }
}
