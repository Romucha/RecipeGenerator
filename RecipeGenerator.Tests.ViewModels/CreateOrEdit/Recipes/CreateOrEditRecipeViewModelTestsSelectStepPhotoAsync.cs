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
        public async Task SelectStepPhotoAsync_Normal()
        {
            var viewModel = GetViewModel();
            await viewModel.InitializeAsync(null);
            await viewModel.AddStepAsync(); 
            var step = viewModel.Steps.First();
            int index = (int)step.Index!;

            await viewModel.SelectStepPhotoAsync(index);

            Assert.NotNull(step);
            Assert.NotNull(step.Photos);
            Assert.NotEmpty(step.Photos);
            Assert.Contains(step.Photos, x => x.SequenceEqual(Data.Properties.Resources.StepNormal));
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task SelectStepPhotoAsync_DoesNothing_WhenStepIdIsInvalid(int index)
        {
            var viewModel = GetViewModel();
            await viewModel.InitializeAsync(null);
            await viewModel.AddStepAsync();
            var step = viewModel.Steps.First();

            await viewModel.SelectStepPhotoAsync(index);

            Assert.NotNull(step);
            Assert.Null(step.Photos);
        }
    }
}
