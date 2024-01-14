using RecipeGenerator.API.DTO.Ingredients;
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
        public async Task Create_Normal()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            await ingredientRepository.Create(createIngredientDTO);
            var createdCount = recipeDbContext.Ingredients.Where(c => string.Equals(c.Name, IngredientSamples.NormalIngredient.Name, StringComparison.OrdinalIgnoreCase)).Count();
            //assert
            Assert.Equal(1, createdCount);
        }


        [Fact]
        public async Task Create_Default()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.DefaultIngredient);
            //act
            await ingredientRepository.Create(createIngredientDTO);
            var createdCount = recipeDbContext.Ingredients.Where(c => string.Equals(c.Name, IngredientSamples.DefaultIngredient.Name, StringComparison.OrdinalIgnoreCase)).Count();
            //assert
            Assert.Equal(1, createdCount);
        }

        [Fact]
        public async Task Create_Empty()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.EmptyIngredient);
            //act
            await ingredientRepository.Create(createIngredientDTO);
            var createdCount = recipeDbContext.Ingredients.Where(c => string.Equals(c.Name, IngredientSamples.EmptyIngredient.Name, StringComparison.OrdinalIgnoreCase)).Count();
            //assert
            Assert.Equal(1, createdCount);
        }

        [Fact]
        public async Task Create_Null()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.NullIngredient);
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await ingredientRepository.Create(createIngredientDTO));
        }
    }
}
