using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.Models.Recipes;
using RecipeGeneratorAPI.Tests.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGeneratorAPI.Tests.Database.Recipes
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
            await recipeRepository.Delete(recipeDbContext.Recipes.FirstOrDefault());
            //assert
            Assert.Single(recipeDbContext.Recipes);
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act & assert
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(new Recipe()));
        }

        [Fact]
        public async Task Delete_EmptyDatabase()
        {
            //arrange

            //act & assert
            await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Delete(RecipeSamples.NormalRecipe));
        }
    }
}
