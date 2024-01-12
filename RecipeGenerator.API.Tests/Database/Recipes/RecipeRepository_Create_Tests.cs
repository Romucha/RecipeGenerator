using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Database.Recipes;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using RecipeGenerator.API.Tests.Samples;
using RecipeGenerator.API.DTO.Recipes;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task Create_Normal()
        {
            //arrange
            var recipe = RecipeSamples.NormalRecipe;
            //act
            CreateRecipeDTO createRecipeDTO = mapper.Map<CreateRecipeDTO>(recipe);
            await recipeRepository.Create(createRecipeDTO);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FirstOrDefaultAsync(c => c.Name == recipe.Name));
        }

        [Fact]
        public async Task Create_Default()
        {
            //arrange
            var recipe = RecipeSamples.DefaultRecipe;
            //act
            CreateRecipeDTO createRecipeDTO = mapper.Map<CreateRecipeDTO>(recipe);
            await recipeRepository.Create(createRecipeDTO);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FirstOrDefaultAsync(c => c.Name == recipe.Name));
        }

        [Fact]
        public async Task Create_Empty()
        {
            //arrange
            var recipe = RecipeSamples.EmptyRecipe;
            //act
            CreateRecipeDTO createRecipeDTO = mapper.Map<CreateRecipeDTO>(recipe);
            await recipeRepository.Create(createRecipeDTO);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FirstOrDefaultAsync(c => c.Name == recipe.Name));
        }

        [Fact]
        public async Task Create_Null()
        {
            //arrange
            CreateRecipeDTO createRecipeDTO = null;
            //act && assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await recipeRepository.Create(createRecipeDTO));
        }
    }
}
