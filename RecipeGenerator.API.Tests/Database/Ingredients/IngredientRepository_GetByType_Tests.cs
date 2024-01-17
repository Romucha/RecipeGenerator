using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Tests.Samples;
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
        public void GetByType_Normal()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            var ingredients = ingredientRepository.GetByType(getIngredientDTO);
            //assert
            Assert.NotNull(ingredients);
            Assert.NotEmpty(ingredients);
            Assert.True(ingredients.All(c => c.IngredientType == IngredientSamples.NormalIngredient.IngredientType));
        }


        [Fact]
        public void GetByType_Null()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NullIngredient);
            //act & assert
            Assert.Throws<InvalidOperationException>(() => ingredientRepository.GetByType(getIngredientDTO));
        }
    }
}
