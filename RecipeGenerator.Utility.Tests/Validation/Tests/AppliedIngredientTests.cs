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
    public class AppliedIngredientTests : AbstractValidationTest<AppliedIngredient>
    {
        protected override IValidationTestData<AppliedIngredient> ValidationTestData { get; set; }
        protected override AbstractValidator<AppliedIngredient> Validator { get; set; }

        public AppliedIngredientTests()
        {
            ValidationTestData = new AppliedIngredientData();

            Validator = new AppliedIngredientValidator();
        }
    }
}
