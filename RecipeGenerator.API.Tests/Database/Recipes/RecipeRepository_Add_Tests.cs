﻿using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Database.Recipes;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using RecipeGenerator.API.Tests.Samples;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task Create_Normal()
        {
            //arrange
            var recipe = RecipeSamples.NormalRecipe;
            //act
            await recipeRepository.Create(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Create_Default()
        {
            //arrange
            var recipe = RecipeSamples.DefaultRecipe;
            //act
            await recipeRepository.Create(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Create()
        {
            //arrange
            var recipe = RecipeSamples.EmptyRecipe;
            //act
            await recipeRepository.Create(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Create_Null()
        {
            //arrange
            var recipe = RecipeSamples.NullRecipe;
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await recipeRepository.Create(recipe));
        }

        [Fact]
        public async Task Create_ExistingId()
        {
            //arrange
            recipeDbContext.Recipes.Add(RecipeSamples.NormalRecipe);
            await recipeDbContext.SaveChangesAsync();
            var recipeCount = recipeDbContext.Recipes.Count();
            //act && assert
            await Assert.ThrowsAnyAsync<ArgumentException>(async () => await recipeRepository.Create(RecipeSamples.NormalRecipe));

        }
    }
}
