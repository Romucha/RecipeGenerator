using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;

namespace RecipeGenerator.Database.UnitsOfWork
{
    /// <summary>
    /// Provides methods for work with database in a single context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ILogger<UnitOfWork> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly RecipeRepository recipeRepository;
        private readonly StepRepository stepRepostiry;
        private readonly AppliedIngredientsRepository appliedIngredientRepository;
        private readonly ApplicableIngredientsRepository applicableIngredientRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Creates a new instanse of <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dbContext">Database context.</param>
        /// <param name="recipeRepository">Repository of recipes.</param>
        /// <param name="stepRepostiry">Repository of steps.</param>
        /// <param name="appliedIngredientRepository">Repository of applied ingredients.</param>
        /// <param name="applicableIngredientRepository">Repository of applicable ingredients.</param>
        /// <param name="mapper">Mapper.</param>
        public UnitOfWork(
            ILogger<UnitOfWork> logger,
            RecipeGeneratorDbContext dbContext,
            RecipeRepository recipeRepository,
            StepRepository stepRepostiry,
            AppliedIngredientsRepository appliedIngredientRepository,
            ApplicableIngredientsRepository applicableIngredientRepository, 
            IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.recipeRepository = recipeRepository;
            this.stepRepostiry = stepRepostiry;
            this.appliedIngredientRepository = appliedIngredientRepository;
            this.applicableIngredientRepository = applicableIngredientRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);
                dbContext.ChangeTracker.Clear();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SaveChangesAsync));
                throw;
            }
        }

        private bool disposed = false;

        public ApplicableIngredientsRepository ApplicableIngredientRepository => applicableIngredientRepository;

        public AppliedIngredientsRepository AppliedIngredientRepository => appliedIngredientRepository;

        public RecipeRepository RecipeRepository => recipeRepository;

        public StepRepository StepRepository => stepRepostiry;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
