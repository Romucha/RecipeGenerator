using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Context
{
    public class RecipeGeneratorDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<ApplicableIngredient> Ingredients { get; set; }

        private readonly ApplicableIngredientsSeeder applicableIngredientsSeeder;
        private readonly IConfiguration configuration;

        public RecipeGeneratorDbContext(
            ApplicableIngredientsSeeder applicableIngredientsSeeder,
            IConfiguration configuration,
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.applicableIngredientsSeeder = applicableIngredientsSeeder;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add seeding here
            //modelBuilder.Entity<Ingredient>().HasData(ingredientGetter.Get().Select(c => mapper.Map<Ingredient>(c)));
            
            var data = Task.Run(applicableIngredientsSeeder.GetEntities);
            data.Wait();
            modelBuilder.Entity<ApplicableIngredient>().HasData(data.Result);
        }
    }
}
