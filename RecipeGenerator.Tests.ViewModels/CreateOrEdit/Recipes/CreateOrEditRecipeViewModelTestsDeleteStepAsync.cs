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
        public async Task DeleteStepAsync_Normal()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;
            var stepId = StepDataCollections.Normal.First(c => c.RecipeId == recipeId).Id;

            await viewModel.InitializeAsync(recipeId);
            var stepsCount = viewModel.Steps.Count;
            var index = viewModel.StepIndex;

            await viewModel.DeleteStepAsync(stepId);

            Assert.DoesNotContain(viewModel.Steps, c => c.Id == stepId);
            Assert.NotEqual(stepsCount, viewModel.Steps.Count);
            Assert.NotEqual(index, viewModel.StepIndex);
        }

        [Fact]
        public async Task DeleteStepAsync_DoesNothing_WhenStepIdIsDefault()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;
            var stepId = 0;

            await viewModel.InitializeAsync(recipeId);
            var stepsCount = viewModel.Steps.Count;
            var index = viewModel.StepIndex;

            await viewModel.DeleteStepAsync(stepId);

            Assert.Equal(stepsCount, viewModel.Steps.Count);
            Assert.Equal(index, viewModel.StepIndex);
        }

        [Fact]
        public async Task DeleteStepAsync_DoesNothing_WhenStepIdIsNegative()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;
            var stepId = -1;

            await viewModel.InitializeAsync(recipeId);
            var stepsCount = viewModel.Steps.Count;
            var index = viewModel.StepIndex;

            await viewModel.DeleteStepAsync(stepId);

            Assert.Equal(stepsCount, viewModel.Steps.Count);
            Assert.Equal(index, viewModel.StepIndex);
        }

        [Fact]
        public async Task DeleteStepAsync_DoesNothing_WhenStepIdIsNonExistent()
        {
            var viewModel = GetViewModel();
            var recipeId = RecipeDataCollections.Normal[0].Id;
            var stepId = int.MaxValue;

            await viewModel.InitializeAsync(recipeId);
            var stepsCount = viewModel.Steps.Count;
            var index = viewModel.StepIndex;

            await viewModel.DeleteStepAsync(stepId);

            Assert.Equal(stepsCount, viewModel.Steps.Count);
            Assert.Equal(index, viewModel.StepIndex);
        }

        [Fact]
        public async Task DeleteStepAsync_DoesNothing_WhenRecipeIdIsNull()
        {
            var viewModel = GetViewModel();
            int? recipeId = null;
            var stepId = RecipeDataCollections.Normal[0].Id;

            await viewModel.InitializeAsync(recipeId);
            var stepsCount = viewModel.Steps.Count;
            var index = viewModel.StepIndex;

            await viewModel.DeleteStepAsync(stepId);

            Assert.Empty(viewModel.Steps);
            Assert.Equal(stepsCount, viewModel.Steps.Count);
            Assert.Equal(index, viewModel.StepIndex);
        }
    }
}
