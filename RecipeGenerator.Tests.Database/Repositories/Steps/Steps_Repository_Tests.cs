using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories.Steps
{
    public class Steps_Repository_Tests : Repository_Tests_Base<Step>
    {
        public Steps_Repository_Tests() : base()
        {
        }

        protected override void EditEntity(Step entity)
        {
            entity.Name = "Updated Step Name";
            entity.Description = "Updated Step Description";
            entity.Index = 1000;
        }
    }
}
