using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Utility.Validation
{
    public class RecipeTests
    {
        protected AbstractValidator<Recipe> Validator { get; set; }

        public RecipeTests()
        {
            Validator = new RecipeValidator();
        }

        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = RecipeData.Normal;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = RecipeData.Default;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = RecipeData.Null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => Validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = RecipeData.Invalid;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
