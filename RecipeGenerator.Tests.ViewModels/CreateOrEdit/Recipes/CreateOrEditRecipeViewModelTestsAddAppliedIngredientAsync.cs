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
        public async Task AddAppliedIngredient_Normal()
        {
            var viewModel = await GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            await viewModel.InitializeAsync(recipeId);
            var selectedIngredientId = viewModel.ApplicableIngredients.Last().Id;
            viewModel.SelectedIngredientId = selectedIngredientId;
            await viewModel.AddAppliedIngredientAsync();

            Assert.Contains(viewModel.AppliedIngredients, c => c.IngredientId == selectedIngredientId);
        }

        [Fact]
        public async Task AddAppliedIngredient_Normal_WhenNotInitialized()
        {
            var viewModel = await GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            var selectedIngredientId = ApplicableIngredientDataCollections.Normal.Last().Id;
            viewModel.SelectedIngredientId = selectedIngredientId;
            await viewModel.AddAppliedIngredientAsync();

            Assert.Contains(viewModel.AppliedIngredients, c => c.IngredientId == selectedIngredientId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        public async Task AddAppliedIngredient_DoesNothing_WhenIngredientIdIsInvalid(int ingredientId)
        {
            var viewModel = await GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            await viewModel.InitializeAsync(recipeId);
            var selectedIngredientId = ingredientId;
            viewModel.SelectedIngredientId = selectedIngredientId;
            await viewModel.AddAppliedIngredientAsync();

            Assert.DoesNotContain(viewModel.AppliedIngredients, c => c.IngredientId == selectedIngredientId);
        }
    }
}
