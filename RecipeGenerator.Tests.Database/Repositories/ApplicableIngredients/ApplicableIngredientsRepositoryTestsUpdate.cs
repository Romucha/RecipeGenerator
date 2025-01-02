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
        public async Task Update_Empty()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = ApplicableIngredientData.Normal.Id;

                var response = await repository.UpdateAsync(id, null, null, null, null, null, null);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(ApplicableIngredientData.Normal.Id, response.Id);
                Assert.Equal(ApplicableIngredientData.Normal.Name, response.Name);
                Assert.Equal(ApplicableIngredientData.Normal.Description, response.Description);
                Assert.Equal(ApplicableIngredientData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(ApplicableIngredientData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(ApplicableIngredientData.Normal.Image, response.Image);
                Assert.Equal(ApplicableIngredientData.Normal.MeasurementType, (MeasurementType)response.MeasurementType);
                Assert.Equal(ApplicableIngredientData.Normal.IngredientType, (IngredientType)response.IngredientType);
                Assert.Equal(ApplicableIngredientData.Normal.Link, response.Link);
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
                var link = new Uri("http://localhost:5000");
                var ingredientType = IngredientType.Vegetables;
                var measurementType = MeasurementType.Volume;
                var image = new byte[] { 1, 2, 3 };

                var updateTime = ApplicableIngredientData.Normal.UpdatedAt;

                var response = await repository.UpdateAsync(id, name, description, link, ingredientType, measurementType, image);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(id, response.Id);
                Assert.Equal(name, response.Name);
                Assert.Equal(description, response.Description);
                Assert.Equal(image, response.Image);
                Assert.Equal(measurementType, (MeasurementType)response.MeasurementType);
                Assert.Equal(ingredientType, (IngredientType)response.IngredientType);
                Assert.Equal(link, response.Link);
                Assert.NotEqual(updateTime, response.UpdatedAt);
            }
        }
    }
}
