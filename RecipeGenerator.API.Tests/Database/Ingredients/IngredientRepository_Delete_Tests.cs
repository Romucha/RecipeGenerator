using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Tests.Database.Recipes;
using RecipeGenerator.API.Tests.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Database.Ingredients
{
    public partial class IngredientRepository_Tests
    {
        [Fact]
        public async Task Delete_Normal()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.NormalIngredient);
            await recipeDbContext.SaveChangesAsync();
            recipeDbContext.ChangeTracker.Clear();
            DeleteIngredientDTO deleteIngredientDTO = mapper.Map<DeleteIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            await ingredientRepository.Delete(deleteIngredientDTO);
            //assert
            Assert.Null(await recipeDbContext.Ingredients.FindAsync(IngredientSamples.NormalIngredient.Id));
        }

        [Fact]
        public async Task Delete_Empty()
        {
            //arrange
            await recipeDbContext.Ingredients.AddAsync(IngredientSamples.EmptyIngredient);
            await recipeDbContext.SaveChangesAsync();
            recipeDbContext.ChangeTracker.Clear();
            DeleteIngredientDTO deleteIngredientDTO = mapper.Map<DeleteIngredientDTO>(IngredientSamples.EmptyIngredient);
            //act
            await ingredientRepository.Delete(deleteIngredientDTO);
            //assert
            Assert.Null(await recipeDbContext.Ingredients.FindAsync(IngredientSamples.EmptyIngredient.Id));

        }

        [Fact]
        public async Task Delete_Null()
        {
            //arrange
            DeleteIngredientDTO deleteIngredientDTO = mapper.Map<DeleteIngredientDTO>(IngredientSamples.NullIngredient);
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await ingredientRepository.Delete(deleteIngredientDTO));
        }
    }
}
