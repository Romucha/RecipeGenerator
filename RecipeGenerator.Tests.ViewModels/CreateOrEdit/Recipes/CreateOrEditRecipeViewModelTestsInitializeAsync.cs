﻿using AutoMapper;
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
        public async Task InitializeAsync_Normal()
        {
            var viewModel = await GetViewModel();
            var recipeId = RecipeData.Normal.Id;

            await viewModel.InitializeAsync(recipeId);

            Assert.Equal(RecipeData.Normal.Name, viewModel.Name);
            Assert.Equal(RecipeData.Normal.Description, viewModel.Description);
            Assert.NotEmpty(viewModel.AppliedIngredients);
            Assert.NotEmpty(viewModel.Steps);
            Assert.Equal(RecipeData.Normal.Image, viewModel.Image);
            Assert.Equal(RecipeData.Normal.CourseType, viewModel.CourseType);
        }

        [Fact]
        public async Task InitializeAsync_Default()
        {
            var viewModel = await GetViewModel();
            var recipeId = 0;

            await viewModel.InitializeAsync(recipeId);

            Assert.Null(viewModel.Name);
            Assert.Null(viewModel.Description);
            Assert.Empty(viewModel.AppliedIngredients);
            Assert.Empty(viewModel.Steps);
            Assert.Null(viewModel.Image);
            Assert.Equal(Models.Recipes.Course.Unknown, viewModel.CourseType);
        }

        [Fact]
        public async Task InitializeAsync_NonExistent()
        {
            var viewModel = await GetViewModel();
            var recipeId = int.MaxValue;

            await viewModel.InitializeAsync(recipeId);

            Assert.Null(viewModel.Name);
            Assert.Null(viewModel.Description);
            Assert.Empty(viewModel.AppliedIngredients);
            Assert.Empty(viewModel.Steps);
            Assert.Null(viewModel.Image);
            Assert.Equal(Models.Recipes.Course.Unknown, viewModel.CourseType);
        }

        [Fact]
        public async Task InitializeAsync_Negative()
        {
            var viewModel = await GetViewModel();
            var recipeId = -1;

            await viewModel.InitializeAsync(recipeId);

            Assert.Null(viewModel.Name);
            Assert.Null(viewModel.Description);
            Assert.Empty(viewModel.AppliedIngredients);
            Assert.Empty(viewModel.Steps);
            Assert.Null(viewModel.Image);
            Assert.Equal(Models.Recipes.Course.Unknown, viewModel.CourseType);
        }
    }
}
