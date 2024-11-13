using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;

namespace RecipeGenerator.Database.Context
{
    public class RecipeGeneratorDbContext : DbContext
    {
        public required DbSet<Recipe> Recipes { get; set; }

        public required DbSet<ApplicableIngredient> ApplicableIngredients { get; set; }

        public required DbSet<Step> Steps { get; set; }

        public required DbSet<AppliedIngredient> AppliedIngredients { get; set; }

        public required DbSet<Measurement> Measurements { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Step>().HasOne(c => c.Recipe).WithMany(c => c.Steps).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AppliedIngredient>().HasOne(c => c.Recipe).WithMany(c => c.Ingredients).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AppliedIngredient>().HasOne(c => c.Measurement);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
