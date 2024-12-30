using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.ApplicableIngredients
{
    public partial class ApplicableIngredientsRepositoryTests
    {
        [Fact]
        public async Task Get_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);
                var id = ApplicableIngredientData.Normal.Id;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(ApplicableIngredientData.Normal.Id, response.Id);
                Assert.Equal(ApplicableIngredientData.Normal.Name, response.Name);
                Assert.Equal(ApplicableIngredientData.Normal.Description, response.Description);
                Assert.Equal(ApplicableIngredientData.Normal.MeasurementType, (MeasurementType)response.MeasurementType);
                Assert.Equal(ApplicableIngredientData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(ApplicableIngredientData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(ApplicableIngredientData.Normal.IngredientType, (IngredientType)response.IngredientType);
                Assert.Equal(ApplicableIngredientData.Normal.Image, response.Image);
                Assert.Equal(ApplicableIngredientData.Normal.Link, response.Link);
            }
        }

        [Fact]
        public async Task Get_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
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
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
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
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
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
