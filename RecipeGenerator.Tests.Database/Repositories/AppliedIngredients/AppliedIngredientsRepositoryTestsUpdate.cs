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
        public async Task Update_Empty()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = AppliedIngredientData.Normal.Id;

                var response = await repository.UpdateAsync(id, null, null, null, null, null, null);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(AppliedIngredientData.Normal.Id, response.Id);
                Assert.Equal(AppliedIngredientData.Normal.Name, response.Name);
                Assert.Equal(AppliedIngredientData.Normal.Description, response.Description);
                Assert.Equal(AppliedIngredientData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(AppliedIngredientData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(AppliedIngredientData.Normal.RecipeId, response.RecipeId);
                Assert.Equal(AppliedIngredientData.Normal.IngredientId, response.IngredientId);
                Assert.Equal(AppliedIngredientData.Normal.MeasurementId, response.MeasurementId);
                Assert.Equal(AppliedIngredientData.Normal.MeasurementValue, response.MeasurementValue);
            }
        }

        [Fact]
        public async Task Update_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = AppliedIngredientData.Normal.Id;
                var name = "Updated";
                var description = "Updated";
                var recipeId = 1;
                var ingredientId = 1;
                var measurementId = 1;
                var measurementValue = 2.5;

                var updateTime = ApplicableIngredientData.Normal.UpdatedAt;

                var response = await repository.UpdateAsync(id, name, description, recipeId, ingredientId, measurementId, measurementValue);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(id, response.Id);
                Assert.Equal(name, response.Name);
                Assert.Equal(description, response.Description);
                Assert.Equal(recipeId, response.RecipeId);
                Assert.Equal(ingredientId, response.IngredientId);
                Assert.Equal(measurementId, response.MeasurementId);
                Assert.Equal(measurementValue, response.MeasurementValue);
                Assert.NotEqual(updateTime, response.UpdatedAt);
            }
        }
    }
}
