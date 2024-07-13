using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories.Recipes
{
    public class Recipes_Repository_Tests : Repository_Tests_Base<Recipe>
    {
        public Recipes_Repository_Tests() : base()
        {
            
        }

        protected override void EditEntity(Recipe entity)
        {
            entity.Name = "Updated Recipe Name";
            entity.Description = "Updated recipe description";
            entity.Portions = 10;
            entity.CourseType = Course.Soup;
            entity.EstimatedTime = TimeSpan.FromHours(10);
            entity.Steps = new List<Step>()
            {
                new Step()
                {
                    Index = 0,
                },
                new Step()
                {
                    Index = 1
                },
                new Step()
                {
                    Index = 2
                }
            };
        }
    }
}
