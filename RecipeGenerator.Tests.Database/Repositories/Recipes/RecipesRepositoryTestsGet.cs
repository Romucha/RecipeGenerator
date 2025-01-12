using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
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
        public async Task Get_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = RecipeData.Normal.Id;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(RecipeData.Normal.Id, response.Id);
                Assert.Equal(RecipeData.Normal.Name, response.Name);
                Assert.Equal(RecipeData.Normal.Description, response.Description);
                Assert.Equal(RecipeData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(RecipeData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(RecipeData.Normal.EstimatedTime, response.EstimatedTime);
                Assert.Equal(RecipeData.Normal.Image, response.Image);
                Assert.Equal(RecipeData.Normal.CourseType, (Course)response.CourseType);
                Assert.Equal(RecipeData.Normal.Portions, response.Portions);
            }
        }

        [Fact]
        public async Task Get_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = 0;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Get_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = int.MaxValue;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Get_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = -1;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }
    }
}
