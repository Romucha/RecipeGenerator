using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Utility.Validation
{
    public class AppliedIngredientTests
    {
        protected AbstractValidator<AppliedIngredient> Validator { get; set; }

        public AppliedIngredientTests()
        {
            Validator = new AppliedIngredientValidator();
        }

        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = AppliedIngredientData.Normal;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = AppliedIngredientData.Default;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = AppliedIngredientData.Null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => Validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = AppliedIngredientData.Invalid;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
