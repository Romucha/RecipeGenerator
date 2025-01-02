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
        public async Task Create_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var recipeId = RecipeData.Normal.Id;
                var applicableIngredientId = ApplicableIngredientData.Normal.Id;

                var response = await repository.CreateAsync(recipeId, applicableIngredientId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.NotEqual(0, response.Id);
                Assert.NotEqual(AppliedIngredientData.Normal.Id, response.Id);
                Assert.Equal(ApplicableIngredientData.Normal.Name, response.Name);
                Assert.Equal(ApplicableIngredientData.Normal.Description, response.Description);
                Assert.Equal(RecipeData.Normal.Id, response.RecipeId);
                Assert.Equal(ApplicableIngredientData.Normal.Id, response.IngredientId);
                Assert.True(context.AppliedIngredients.Any(c => c.Id == response.Id));
            }
        }
    }
}
