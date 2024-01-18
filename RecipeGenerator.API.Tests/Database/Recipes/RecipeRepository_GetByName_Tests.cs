using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.API.Tests.Samples;
using RecipeGenerator.API.DTO.Recipes;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests
    {
        [Fact]
        public async Task GetByName_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            GetRecipeDTO getRecipeDTO = mapper.Map<GetRecipeDTO>(RecipeSamples.NormalRecipes.FirstOrDefault());
            //act
            var recipe = await recipeRepository.GetByName(getRecipeDTO);
            //assert
            Assert.NotNull(recipe);
        }

        [Fact]
        public async Task GetByName_IncorrectName()
        {
            //arrange
            var name = "a-random-name";
            GetRecipeDTO getRecipeDTO = mapper.Map<GetRecipeDTO>(new GetRecipeDTO()
            {
                Name = name
            });
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act
            var recipe = await recipeRepository.GetByName(getRecipeDTO);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_EmptyDatabase()
        {
            //arrange
            GetRecipeDTO getRecipeDTO = new GetRecipeDTO
            {
                Name = RecipeSamples.NormalRecipe.Name,
            };
            //act
            var recipe = await recipeRepository.GetByName(getRecipeDTO);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_EmptyName()
        {
            //arrange
            GetRecipeDTO name = new GetRecipeDTO();
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetByName_NullName()
        {
            //arrange
            GetRecipeDTO name = new GetRecipeDTO()
            {
                Name = null,
            };
            //act
            var recipe = await recipeRepository.GetByName(name);
            //assert
            Assert.Null(recipe);
        }
    }
}
