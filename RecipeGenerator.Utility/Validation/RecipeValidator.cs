using FluentValidation;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.CourseType).NotEmpty();
            RuleFor(x => x.EstimatedTime).NotEmpty();
            RuleFor(x => x.Image).NotNull();
            RuleFor(x => x.Ingredients).NotNull();
            RuleForEach(x => x.Ingredients).NotNull();
            RuleFor(x => x.Steps).NotNull();
            RuleForEach(x => x.Steps).NotNull();
            RuleFor(x => x.Portions).NotEmpty();
        }
    }
}
