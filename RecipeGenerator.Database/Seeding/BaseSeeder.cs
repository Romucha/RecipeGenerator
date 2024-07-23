using RecipeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Seeding
{
    /// <summary>
    /// Provides functionality of seeding database with entities.
    /// </summary>
    /// <typeparam name="Entity">Database entity.</typeparam>
    public abstract class BaseSeeder<Entity> where Entity : class, IRecipeGeneratorEntity
    {
        /// <summary>
        /// Get list of entites to seed a database.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable<Entity>> GetEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
