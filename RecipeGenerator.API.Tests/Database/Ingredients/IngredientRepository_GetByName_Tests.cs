using RecipeGenerator.API.DTO.Ingredients;
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
        public async Task GetByName_Normal()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.NormalIngredient);
            await recipeDbContext.SaveChangesAsync();
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            var recipe = await ingredientRepository.GetByName(getIngredientDTO);
            //assert
            Assert.NotNull(recipe);
            Assert.Equal(IngredientSamples.NormalIngredient.Name, recipe.Name);
        }

        [Fact]
        public async Task GetByName_Default()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.DefaultIngredient);
            await recipeDbContext.SaveChangesAsync();
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.DefaultIngredient);
            //act
            var recipe = await ingredientRepository.GetByName(getIngredientDTO);
            //assert
            Assert.NotNull(recipe);
            Assert.Equal(IngredientSamples.DefaultIngredient.Name, recipe.Name);
        }

        [Fact]
        public async Task GetByName_NonExistent()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            var recipe = await ingredientRepository.GetByName(getIngredientDTO);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_Null()
        {
            //arrange
            GetIngredientDTO getIngredientDTO = mapper.Map<GetIngredientDTO>(IngredientSamples.NullIngredient);
            //act & assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await ingredientRepository.GetByName(getIngredientDTO));
        }
    }
}
