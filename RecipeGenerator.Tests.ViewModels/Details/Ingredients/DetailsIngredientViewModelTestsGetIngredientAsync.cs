using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Tests.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.ViewModels.Details.Ingredients;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.Details.Ingredients
{
    public partial class DetailsIngredientViewModelTests
    {
        [Fact]
        public async Task GetIngredientAsync_Normal()
        {
            var ingredient = ApplicableIngredientDataCollections.Normal[0];
            var viewModel = GetViewModel();
            var ingredientId = ingredient.Id;

            await viewModel.GetIngredientAsync(ingredientId);

            Assert.Equal(ingredient.Name, viewModel.Name);
            Assert.Equal(ingredient.Description, viewModel.Description);
            Assert.Equal(Convert.ToBase64String(ingredient.Image), viewModel.Image);
            Assert.Equal(ingredient.IngredientType, viewModel.IngredientType);
            Assert.Equal(ingredient.CreatedAt.Date, viewModel.CreatedAt.Date);
            Assert.Equal(ingredient.Link, viewModel.Link);
            Assert.Equal(ingredient.MeasurementType, viewModel.MeasurementType);
            Assert.Equal(ingredient.UpdatedAt.Date, viewModel.UpdatedAt.Date);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public async Task GetIngredientAsync_DoesNothing(int ingredientId)
        {
            var ingredient = ApplicableIngredientData.Default;
            var viewModel = GetViewModel();

            await viewModel.GetIngredientAsync(ingredientId);

            Assert.Equal(ingredient.Name, viewModel.Name);
            Assert.Equal(ingredient.Description, viewModel.Description);
            Assert.Equal(Convert.ToBase64String(ingredient.Image), viewModel.Image);
            Assert.Equal(ingredient.IngredientType, viewModel.IngredientType);
            Assert.Equal(ingredient.CreatedAt.Date, viewModel.CreatedAt.Date);
            Assert.Equal(ingredient.Link, viewModel.Link);
            Assert.Equal(ingredient.MeasurementType, viewModel.MeasurementType);
            Assert.Equal(ingredient.UpdatedAt.Date, viewModel.UpdatedAt.Date);
        }
    }
}
