using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Utility.Validation;
using RecipeGenerator.Tests.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Utility.Validation
{
    public class ApplicableIngredientTests
    {
        protected AbstractValidator<ApplicableIngredient> Validator { get; set; }

        public ApplicableIngredientTests()
        {
            Validator = new ApplicableIngredientValidator();
        }

        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = ApplicableIngredientData.Normal;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = ApplicableIngredientData.Default;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = ApplicableIngredientData.Null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => Validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = ApplicableIngredientData.Invalid;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
