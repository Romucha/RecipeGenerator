using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGeneratorAPI.Tests.Samples;

namespace RecipeGeneratorAPI.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task GetByName_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act
            var recipe = await recipeRepository.GetByName(RecipeSamples.NormalRecipes.FirstOrDefault().Name);
            //assert
            Assert.NotNull(recipe);
        }

        [Fact]
        public async Task GetByName_IncorrectName()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();

            var name = "a-random-name";
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_EmptyDatabase()
        {
            //arrange
            var name = RecipeSamples.NormalRecipe.Name;
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_EmptyName()
        {
            //arrange
            var name = string.Empty;
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_NullName()
        {
            //arrange
            string name = null;
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }
    }
}
