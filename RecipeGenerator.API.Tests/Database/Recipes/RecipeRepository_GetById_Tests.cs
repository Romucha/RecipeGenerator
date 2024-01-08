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
using RecipeGenerator.API.Tests.Samples;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task GetById_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act
            var recipe = await recipeRepository.GetById(RecipeSamples.NormalRecipes.FirstOrDefault().Id);
            //assert
            Assert.NotNull(recipe);
        }

        [Fact]
        public async Task GetById_IncorrectId()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();

            var id = Guid.NewGuid();
            //act
            var recipe = await recipeRepository.GetById(id);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetById_EmptyDatabase()
        {
            //arrange
            var guid = RecipeSamples.NormalRecipe.Id;
            //act
            var recipe = await recipeRepository.GetById(guid);
            //assert
            Assert.Null(recipe);
        }
    }
}
