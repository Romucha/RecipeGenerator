using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.Details.Ingredients;
using RecipeGenerator.ViewModels.Details.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.Details.Recipes
{
    public partial class DetailsRecipesViewModelTests
    {
        [Fact]
        public async Task GetRecipeAsync_Normal()
        {
            var recipe = RecipeDataCollections.Normal[0];
            var viewModel = GetViewModel();
            var recipeId = recipe.Id;

            await viewModel.GetRecipeAsync(recipeId);

            Assert.Equal(recipe.Name, viewModel.Name);
            Assert.Equal(recipe.Description, viewModel.Description);
            Assert.Equal(Convert.ToBase64String(recipe.Image), viewModel.Image);
            Assert.Equal(recipe.CourseType, viewModel.CourseType);
            Assert.Equal(recipe.CreatedAt.Date, viewModel.CreatedAt.Date);
            Assert.Equal(recipe.EstimatedTime, viewModel.EstimatedTime);
            Assert.Equal(recipe.Portions, viewModel.Portions);
            Assert.Equal(recipe.UpdatedAt.Date, viewModel.UpdatedAt.Date);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public async Task GetIngredientAsync_DoesNothing(int recipeId)
        {
            var recipe = RecipeData.Default;
            var viewModel = GetViewModel();

            await viewModel.GetRecipeAsync(recipeId);

            Assert.Equal(recipe.Name, viewModel.Name);
            Assert.Equal(recipe.Description, viewModel.Description);
            Assert.Equal(Convert.ToBase64String(recipe.Image), viewModel.Image);
            Assert.Equal(recipe.CourseType, viewModel.CourseType);
            Assert.Equal(recipe.CreatedAt.Date, viewModel.CreatedAt.Date);
            Assert.Equal(recipe.EstimatedTime, viewModel.EstimatedTime);
            Assert.Equal(recipe.Portions, viewModel.Portions);
            Assert.Equal(recipe.UpdatedAt.Date, viewModel.UpdatedAt.Date);
        }
    }
}
