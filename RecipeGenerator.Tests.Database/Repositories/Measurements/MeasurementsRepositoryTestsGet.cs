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
        [Fact]
        public async Task Get_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = MeasurementData.Normal.Id;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(MeasurementData.Normal.Id, response.Id);
                Assert.Equal(MeasurementData.Normal.Name, response.Name);
                Assert.Equal(MeasurementData.Normal.Description, response.Description);
                Assert.Equal(MeasurementData.Normal.MeasurementType, (MeasurementType)response.MeasurementType!);
                Assert.Equal(MeasurementData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(MeasurementData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(MeasurementData.Normal.ConversionCoefficient, response.ConversionCoefficient);
                Assert.Equal(MeasurementData.Normal.IsBase, response.IsBase);
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
