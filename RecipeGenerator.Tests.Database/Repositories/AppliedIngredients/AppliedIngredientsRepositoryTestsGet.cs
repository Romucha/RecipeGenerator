using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.AppliedIngredients
{
    public partial class AppliedIngredientsRepositoryTests
    {
        [Fact]
        public async Task Get_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = AppliedIngredientData.Normal.Id;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(AppliedIngredientData.Normal.Id, response.Id);
                Assert.Equal(AppliedIngredientData.Normal.Name, response.Name);
                Assert.Equal(AppliedIngredientData.Normal.Description, response.Description);
                Assert.Equal(AppliedIngredientData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(AppliedIngredientData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(AppliedIngredientData.Normal.MeasurementId, response.MeasurementId);
                Assert.Equal(AppliedIngredientData.Normal.MeasurementValue, response.MeasurementValue);
                Assert.Equal(AppliedIngredientData.Normal.IngredientId, response.IngredientId);
                Assert.Equal(AppliedIngredientData.Normal.RecipeId, response.RecipeId);
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
