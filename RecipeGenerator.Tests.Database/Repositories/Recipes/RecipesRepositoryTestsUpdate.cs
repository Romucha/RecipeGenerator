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
        public async Task Update_Empty()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = ApplicableIngredientData.Normal.Id;

                var response = await repository.UpdateAsync(id, null, null, null, null, null, null);
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
        public async Task Update_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = ApplicableIngredientData.Normal.Id;
                var name = "Updated";
                var description = "Updated";
                var estimatedTime = TimeSpan.FromHours(1000);
                var image = new byte[] { 1, 2, 3 };
                var courseType = Course.CheesePlate;
                var portions = 99;

                var updateTime = ApplicableIngredientData.Normal.UpdatedAt;

                var response = await repository.UpdateAsync(id, name, description, image, courseType, estimatedTime, portions);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(id, response.Id);
                Assert.Equal(name, response.Name);
                Assert.Equal(description, response.Description);
                Assert.Equal(estimatedTime, response.EstimatedTime);
                Assert.Equal(image, response.Image);
                Assert.Equal(courseType, (Course)response.CourseType);
                Assert.Equal(portions, response.Portions);
                Assert.NotEqual(updateTime, response.UpdatedAt);
            }
        }
    }
}
