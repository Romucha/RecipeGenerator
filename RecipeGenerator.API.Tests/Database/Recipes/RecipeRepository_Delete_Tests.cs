using Microsoft.EntityFrameworkCore;
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
            //act
            await recipeRepository.Delete(RecipeSamples.NormalRecipes.FirstOrDefault());
            //assert
            Assert.False(recipeDbContext.Recipes.Contains(RecipeSamples.NormalRecipes.FirstOrDefault()));
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(RecipeSamples.DefaultRecipe));
        }

        [Fact]
        public async Task Delete_EmptyDatabase()
        {
            //arrange

            //act & assert
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(RecipeSamples.NormalRecipe));
        }

        [Fact]
        public async Task Delete_Null()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(async () => await recipeRepository.Delete(RecipeSamples.NullRecipe));

        }
    }
}
