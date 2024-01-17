using Moq;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Recipes;
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
        public async Task Update_Normal()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.NormalIngredient);
            await recipeDbContext.SaveChangesAsync();
            //act
            string alteredName = Guid.NewGuid().ToString();
            var originalingredient = IngredientSamples.NormalIngredient;
            UpdateIngredientDTO updateIngredientDTO = mapper.Map<UpdateIngredientDTO>(originalingredient);
            updateIngredientDTO.Name = alteredName;
            await ingredientRepository.Update(updateIngredientDTO);
            //assert
            Assert.Equal(alteredName, recipeDbContext.Ingredients.Find(IngredientSamples.NormalIngredient.Id).Name);
        }


        [Fact]
        public async Task Update_NonExistent()
        {
            // arrange
            await recipeDbContext.Ingredients.AddRangeAsync(IngredientSamples.NormalIngredients);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            string alteredName = Guid.NewGuid().ToString();
            var updateRecipeDTO = mapper.Map<UpdateIngredientDTO>(IngredientSamples.NormalIngredient);
            updateRecipeDTO.Name = alteredName;
            await Assert.ThrowsAsync<NullReferenceException>(async () => await ingredientRepository.Update(updateRecipeDTO));
        }

        [Fact]
        public async Task Update_Null()
        {
            //arrange
            var updateRecipeDTO = mapper.Map<UpdateIngredientDTO>(IngredientSamples.NullIngredient);
            //act & assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await ingredientRepository.Update(updateRecipeDTO));

        }
    }
}
