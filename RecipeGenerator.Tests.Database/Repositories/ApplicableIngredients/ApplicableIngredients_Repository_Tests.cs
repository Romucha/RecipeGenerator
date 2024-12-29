using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories.ApplicableIngredients
{
    public class ApplicableIngredients_Repository_Tests : Repository_Tests_Base<ApplicableIngredient>
    {
        protected override void EditEntity(ApplicableIngredient entity)
        {
            entity.Name = "Updated Ingredient Name";
            entity.Description = "Updated entity description";
            entity.IngredientType = IngredientType.Meat;
        }
    }
}
