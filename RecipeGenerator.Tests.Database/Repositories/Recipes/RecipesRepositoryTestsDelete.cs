﻿using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.Recipes
{
    public partial class RecipesRepositoryTests
    {
        [Fact]
        public async Task Delete_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var expectedId = RecipeData.Normal.Id;
                var expectedName = RecipeData.Normal.Name;

                var response = await repository.DeleteAsync(expectedId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(RecipeData.Normal.Id, response.Id);
                Assert.Equal(RecipeData.Normal.Name, response.Name);
                Assert.False(context.Recipes.Any(c => c.Id == response.Id));
            }
        }

        [Fact]
        public async Task Delete_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = 0;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = int.MaxValue;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Delete_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = -1;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }
    }
}