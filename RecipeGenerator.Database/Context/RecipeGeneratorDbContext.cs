using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;

namespace RecipeGenerator.Database.Context
{
    public class RecipeGeneratorDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<ApplicableIngredient> ApplicableIngredients { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<AppliedIngredient> AppliedIngredients { get; set; }

        private readonly IConfiguration configuration;

        public RecipeGeneratorDbContext(
            IConfiguration configuration,
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.configuration = configuration;
            if (Database.IsRelational())
            {
                Database.EnsureCreated();
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
