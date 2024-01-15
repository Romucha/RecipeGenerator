using RecipeGenerator.API.DTO.AppliedIngredients;
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
        public async Task GetById_Normal()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.NormalIngredient);
            await recipeDbContext.SaveChangesAsync();
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            var ingredient = await ingredientRepository.GetById(getIngredientDTO);
            //assert
            Assert.NotNull(ingredient);
            Assert.Equal(IngredientSamples.NormalIngredient.Name, ingredient.Name);
        }

        [Fact]
        public async Task GetById_Default()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.DefaultIngredient);
            //act
            var ingredient = await ingredientRepository.GetById(getIngredientDTO);
            //assert
            Assert.Null(ingredient);
        }

        [Fact]
        public async Task GetById_Null()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NullIngredient);
            //act && assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await ingredientRepository.GetById(getIngredientDTO));
        }
    }
}
