using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class ApplicableIngredientValidator : AbstractValidator<ApplicableIngredient>
    {
        public ApplicableIngredientValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.Image).NotNull();
            RuleFor(x => x.MeasurementType).NotNull();
            RuleFor(x => x.Link);
        }
    }
}
