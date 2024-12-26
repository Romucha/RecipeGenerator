using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public class ApplicableIngredientTests : AbstractValidationTest<ApplicableIngredient>
    {
        protected override IValidationTestData<ApplicableIngredient> ValidationTestData { get; set; }
        protected override AbstractValidator<ApplicableIngredient> Validator { get; set; }

        public ApplicableIngredientTests()
        {
            ValidationTestData = new ApplicableIngredientData();

            Validator = new ApplicableIngredientValidator();
        }
    }
}
