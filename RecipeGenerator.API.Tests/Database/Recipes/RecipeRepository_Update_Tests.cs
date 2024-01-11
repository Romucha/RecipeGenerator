using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Tests.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task Update_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            recipeDbContext.ChangeTracker.Clear();
            //act
            string alteredName = Guid.NewGuid().ToString();
            var originalrecipe = await recipeDbContext.Recipes.FirstOrDefaultAsync();
            UpdateRecipeDTO updateRecipeDTO = mapper.Map<UpdateRecipeDTO>(originalrecipe);
            updateRecipeDTO.Name = alteredName;
            await recipeRepository.Update(updateRecipeDTO);
            //assert
            Assert.Equal(alteredName, recipeDbContext.Recipes.FirstOrDefault().Name);
        }

        [Fact]
        public async Task Update_NonExistent()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            recipeDbContext.ChangeTracker.Clear();
            //act & assert
            string alteredName = Guid.NewGuid().ToString();
            var updateRecipeDTO = mapper.Map<UpdateRecipeDTO>(RecipeSamples.NormalRecipe);
            updateRecipeDTO.Name = alteredName;
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Update(updateRecipeDTO));
        }

        [Fact]
        public async Task Update_Null()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await recipeRepository.Update(null));
        }
    }
}
