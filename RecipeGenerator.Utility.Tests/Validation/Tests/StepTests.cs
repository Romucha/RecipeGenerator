using FluentValidation;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public class StepTests : AbstractValidationTest<Step>
    {
        protected override IValidationTestData<Step> ValidationTestData { get; set; }
        protected override AbstractValidator<Step> Validator { get; set; }

        public StepTests()
        {
            ValidationTestData = new StepData();

            Validator = new StepValidator();
        }
    }
}
