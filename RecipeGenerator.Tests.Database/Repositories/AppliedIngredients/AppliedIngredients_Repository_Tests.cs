using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories.AppliedIngredients
{
    public class AppliedIngredients_Repository_Tests : Repository_Tests_Base<AppliedIngredient>
    {
        public AppliedIngredients_Repository_Tests() : base()
        {
            
        }

        protected override void EditEntity(AppliedIngredient entity)
        {
            entity.RecipeId = Guid.NewGuid();
        }
    }
}
