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

namespace RecipeGenerator.Tests.Database.Repositories.Measurements
{
    public partial class MeasurementsRepositoryTests
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
                Assert.NotEqual(ApplicableIngredientData.Normal.Id, response.Id);
                Assert.Equal(string.Empty, response.Name);
                Assert.Equal(string.Empty, response.Description);
                Assert.Equal(MeasurementType.None, (MeasurementType)response.MeasurementType!);
                Assert.Equal(0, response.ConversionCoefficient);
                Assert.True(context.Measurements.Any(c => c.Id == response.Id));
            }
        }
    }
}
