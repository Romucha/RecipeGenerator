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
        public async Task DeleteAppliedIngredientAsync_Normal()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;
            var ingredientId = AppliedIngredientDataCollections.Normal.First(c => c.RecipeId == recipeId).Id;

            await viewModel.InitializeAsync(recipeId);
            var ingredientsCount = viewModel.AppliedIngredients.Count;

            await viewModel.DeleteAppliedIngredientAsync(ingredientId);

            Assert.DoesNotContain(viewModel.AppliedIngredients, c => c.IngredientId == ingredientId);
            Assert.NotEqual(ingredientsCount, viewModel.AppliedIngredients.Count);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public async Task DeleteAppliedIngredientAsync_DoesNothing_WhenIngredientIdIsInvalid(int ingredientId)
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;

            await viewModel.InitializeAsync(recipeId);
            var ingredientsCount = viewModel.AppliedIngredients.Count;

            await viewModel.DeleteAppliedIngredientAsync(ingredientId);

            Assert.NotEmpty(viewModel.AppliedIngredients);
            Assert.Equal(ingredientsCount, viewModel.AppliedIngredients.Count);
        }

        [Fact]
        public async Task DeleteAppliedIngredientAsync_DoesNothing_WhenRecipeIdIsNull()
        {
            var viewModel = GetViewModel();
            int? recipeId = null;
            var ingredientId = AppliedIngredientDataCollections.Normal.First().Id;

            await viewModel.InitializeAsync(recipeId);
            var ingredientsCount = viewModel.AppliedIngredients.Count;

            await viewModel.DeleteAppliedIngredientAsync(ingredientId);

            Assert.Empty(viewModel.AppliedIngredients);
            Assert.Equal(ingredientsCount, viewModel.AppliedIngredients.Count);
        }
    }
}
