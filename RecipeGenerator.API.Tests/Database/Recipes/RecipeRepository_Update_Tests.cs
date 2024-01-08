using Microsoft.EntityFrameworkCore;
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
            string alteredName = Guid.NewGuid().ToString();
            //act
            RecipeSamples.NormalRecipes.FirstOrDefault().Name = alteredName;
            await recipeRepository.Update(RecipeSamples.NormalRecipes.FirstOrDefault());
            //assert
            Assert.Equal(alteredName, recipeDbContext.Recipes.FirstOrDefault().Name);
        }

        [Fact]
        public async Task Update_NonExistent()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            string alteredName = Guid.NewGuid().ToString();
            //act & assert
            RecipeSamples.DefaultRecipe.Name = alteredName;
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await recipeRepository.Update(RecipeSamples.DefaultRecipe));
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
