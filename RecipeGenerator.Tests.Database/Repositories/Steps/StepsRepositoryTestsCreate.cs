using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.Steps
{
    public partial class StepsRepositoryTests
    {
        [Fact]
        public async Task Create_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var recipeId = RecipeData.Normal.Id;

                var response = await repository.CreateAsync(recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.NotEqual(0, response.Id);
                Assert.NotEqual(StepData.Normal.Id, response.Id);
                Assert.Equal(string.Empty, response.Name);
                Assert.Equal(string.Empty, response.Description);
                Assert.Equal(recipeId, response.RecipeId);
                Assert.Equal(0, response.Index);
                Assert.Equal(new List<byte[]>(), response.Photos);
            }
        }
    }
}
