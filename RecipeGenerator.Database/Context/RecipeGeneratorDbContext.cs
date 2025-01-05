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
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<ApplicableIngredient> ApplicableIngredients { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<AppliedIngredient> AppliedIngredients { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        private readonly IConfiguration configuration;

        public RecipeGeneratorDbContext(
            IConfiguration configuration,
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.configuration = configuration;
            if (Database.IsRelational())
            {
                Database.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureApplicableIngredients(modelBuilder);
            ConfigureAppliedIngredients(modelBuilder);
            ConfigureRecipes(modelBuilder);
            ConfigureSteps(modelBuilder);
            ConfigureMeasurements(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        private void ConfigureRecipes(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Recipe>()
                .HasKey(c => c.Id);
            modelBuilder
                .Entity<Recipe>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Recipe>()
                .HasMany(c => c.Ingredients)
                .WithOne(c => c.Recipe)
                .HasForeignKey(c => c.RecipeId);

            modelBuilder
                .Entity<Recipe>()
                .HasMany(c => c.Steps)
                .WithOne(c => c.Recipe)
                .HasForeignKey(c => c.RecipeId);

            modelBuilder
                .Entity<Recipe>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder
                .Entity<Recipe>()
                .Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigureSteps(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Step>()
                .HasKey(c => c.Id);
            modelBuilder
                .Entity<Step>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Step>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder
                .Entity<Step>()
                .Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder
                .Entity<Step>()
                .HasOne(c => c.Recipe)
                .WithMany(c => c.Steps)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(c => c.RecipeId);
        }

        private void ConfigureAppliedIngredients(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AppliedIngredient>()
                .HasKey(c => c.Id);
            modelBuilder
                .Entity<AppliedIngredient>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<AppliedIngredient>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder
                .Entity<AppliedIngredient>()
                .Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<AppliedIngredient>()
                .HasOne(c => c.Recipe)
                .WithMany(c => c.Ingredients)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(c => c.RecipeId)
                .HasForeignKey(c => c.IngredientId);

            modelBuilder
                .Entity<AppliedIngredient>()
                .HasOne(c => c.Measurement)
                .WithMany(c => c.Ingredients)
                .HasForeignKey(c => c.MeasurementId);
        }

        private void ConfigureApplicableIngredients(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ApplicableIngredient>()
                .HasKey(c => c.Id);
            modelBuilder
                .Entity<ApplicableIngredient>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<ApplicableIngredient>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder
                .Entity<ApplicableIngredient>()
                .Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigureMeasurements(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Measurement>()
                .HasKey(c => c.Id);
            modelBuilder
                .Entity<Measurement>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Measurement>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder
                .Entity<Measurement>()
                .Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
