using RecipeGenerator.Models;

namespace RecipeGenerator.Database.Seeding
{
    /// <summary>
    /// Provides functionality of seeding database with entities.
    /// </summary>
    public abstract class BaseSeeder<Entity> where Entity : class
    {
        /// <summary>
        /// Gets list of entites.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Entity> GetEntities();

        /// <summary>
        /// Gets list of entites asynchronously.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable<Entity>> GetEntitiesAsync();
    }
}
