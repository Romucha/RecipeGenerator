using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Localization.Models.Models;
using RecipeGenerator.Settings;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.CreateOrEdit.Recipes
{
    public partial class CreateOrEditRecipeViewModelTests
    {
        [Fact]
        public async Task CreateAsync_Normal()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            await viewModel.InitializeAsync(recipeId);
            await viewModel.CreateAsync();

            using (var context = GetDbContext())
            {
                var recipe = await context.Recipes.FindAsync(viewModel.RecipeId);
                Assert.NotNull(recipe);
                Assert.Equal(RecipeDataCollections.Normal[0].Name, recipe.Name);
                Assert.Equal(RecipeDataCollections.Normal[0].Description, recipe.Description);
                Assert.Equal(RecipeDataCollections.Normal[0].Image, recipe.Image);
                Assert.Equal(RecipeDataCollections.Normal[0].CourseType, recipe.CourseType);
            }
        }

        [Fact]
        public async Task CreateAsync_Normal_WhenNotInitialized()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            await viewModel.CreateAsync();

            using (var context = GetDbContext())
            {
                var recipe = await context.Recipes.FindAsync(viewModel.RecipeId);
                Assert.NotNull(recipe);
                Assert.Equal(RecipeData.Default.Name, recipe.Name);
                Assert.Equal(RecipeData.Default.Description, recipe.Description);
                Assert.Equal(RecipeData.Default.Image, recipe.Image);
                Assert.Equal(RecipeData.Default.CourseType, recipe.CourseType);
            }
        }

        [Fact]
        public async Task CreateAsync_Normal_WhenRecipeIdIsDefault()
        {
            var viewModel = GetViewModel();
            var recipeId = 0;

            await viewModel.InitializeAsync(recipeId);
            await viewModel.CreateAsync();

            using (var context = GetDbContext())
            {
                var recipe = await context.Recipes.FindAsync(viewModel.RecipeId);
                Assert.NotNull(recipe);
                Assert.Equal(RecipeData.Default.Name, recipe.Name);
                Assert.Equal(RecipeData.Default.Description, recipe.Description);
                Assert.Equal(RecipeData.Default.Image, recipe.Image);
                Assert.Equal(RecipeData.Default.CourseType, recipe.CourseType);
            }
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task CreateAsync_Normal_WhenRecipeIdIsInvalid(int recipeId)
        {
            var viewModel = GetViewModel();

            await viewModel.InitializeAsync(recipeId);
            await viewModel.CreateAsync();

            using (var context = GetDbContext())
            {
                var recipe = await context.Recipes.FindAsync(viewModel.RecipeId);
                Assert.Null(recipe);
            }
        }
    }
}
