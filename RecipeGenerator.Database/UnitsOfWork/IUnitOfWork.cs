using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models;

namespace RecipeGenerator.Database.UnitsOfWork
{
    /// <summary>
    /// Provides singatures of methods for work for with database in a single context.
    /// </summary>
    public interface IUnitOfWork
    {
        ApplicableIngredientRepository ApplicableIngredientRepository { get; }

        AppliedIngredientRepository AppliedIngredientRepository { get; }

        RecipeRepository RecipeRepository { get; }

        StepRepository StepRepository { get; }

        /// <summary>
        /// Save changes in database.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
