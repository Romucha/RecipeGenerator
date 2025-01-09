using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.Measurements
{
    public partial class MeasurementsRepositoryTests
    {
        [Theory]
        [InlineData(-1, 0, "", 3)]
        [InlineData(0, -1, "", 3)]
        [InlineData(0, -1, null, 3)]
        [InlineData(-1, 0, null, 3)]
        [InlineData(0, 0, "", 3)]
        [InlineData(0, 0, null, 3)]
        [InlineData(1, 1, null, 1)]
        [InlineData(2, 0, null, 2)]
        [InlineData(0, 0, $"{nameof(MeasurementDataCollections.Normal)}_1", 1)]
        [InlineData(0, 0, $"{nameof(MeasurementDataCollections.Normal)}", 3)]
        [InlineData(-1, 0, $"{nameof(MeasurementDataCollections.Normal)}", 3)]
        [InlineData(0, -1, $"{nameof(MeasurementDataCollections.Normal)}", 3)]
        [InlineData(0, 0, $"{nameof(MeasurementDataCollections)}", 0)]
        public async Task GetAll_Normal(int pageSize, int pageNumber, string? filterString, int expectedCount)
        {
            using (var context = await DatabaseData.ProvideDbContext().WithCollections())
            {
                var repository = GetRepository(context);
                var id = ApplicableIngredientData.Normal.Id;

                var response = await repository.GetAllAsync(pageSize, pageNumber, filterString);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(expectedCount, response.Items.Count());
                Assert.Equal(pageSize, response.PageSize);
                Assert.Equal(pageNumber, response.PageNumber);
                Assert.Equal(MeasurementDataCollections.Normal.Count, response.TotalCount);
            }
        }
    }
}
