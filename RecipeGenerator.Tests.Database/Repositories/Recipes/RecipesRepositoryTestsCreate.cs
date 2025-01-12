using AutoMapper;
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
        public async Task Create_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var response = await repository.CreateAsync();
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.NotEqual(0, response.Id);
                Assert.NotEqual(RecipeData.Normal.Id, response.Id);
                Assert.Equal(string.Empty, response.Name);
                Assert.Equal(string.Empty, response.Description);
                Assert.Equal(TimeSpan.Zero, response.EstimatedTime);
                Assert.Equal([], response.Image);
                Assert.Equal(Course.Unknown, (Course)response.CourseType);
                Assert.Equal(0, response.Portions);
            }
        }
    }
}
