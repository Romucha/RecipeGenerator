using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class AppliedIngredientValidator : AbstractValidator<AppliedIngredient>
    {
        public AppliedIngredientValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.MeasurementValue).NotNull();
            RuleFor(x => x.IngredientId).NotEmpty();
            RuleFor(x => x.ApplicableIngredient);
            RuleFor(x => x.MeasurementId).NotEmpty();
            RuleFor(x => x.Measurement);
            RuleFor(x => x.RecipeId).NotEmpty();
            RuleFor(x => x.Recipe);
        }
    }
}
