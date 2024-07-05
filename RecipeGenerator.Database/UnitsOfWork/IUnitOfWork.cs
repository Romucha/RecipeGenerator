using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.UnitsOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
