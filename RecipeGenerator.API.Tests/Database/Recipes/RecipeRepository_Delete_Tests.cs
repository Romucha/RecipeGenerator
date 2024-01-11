using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Recipes;
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
        public async Task Delete_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            var recipe = RecipeSamples.NormalRecipes.FirstOrDefault();
            //act
            var deleterecipedto = mapper.Map<DeleteRecipeDTO>(recipe);
            await recipeRepository.Delete(deleterecipedto);
            //assert
            Assert.False(recipeDbContext.Recipes.Contains(RecipeSamples.NormalRecipes.FirstOrDefault()));
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            var recipe = RecipeSamples.DefaultRecipe;
            //act & assert
            var deleterecipedto = mapper.Map<DeleteRecipeDTO>(recipe);
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(deleterecipedto));
        }

        [Fact]
        public async Task Delete_EmptyDatabase()
        {
            //arrange
            var recipe = RecipeSamples.NormalRecipe;
            //act & assert
            var deleterecipedto = mapper.Map<DeleteRecipeDTO>(recipe);
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(deleterecipedto));
        }

        [Fact]
        public async Task Delete_Null()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            DeleteRecipeDTO deleteRecipeDTO = null;
            await Assert.ThrowsAnyAsync<ArgumentNullException>(async () => await recipeRepository.Delete(deleteRecipeDTO));

        }
    }
}
