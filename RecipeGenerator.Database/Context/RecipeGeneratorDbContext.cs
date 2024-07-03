using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        internal DbSet<Recipe> Recipes { get; set; }

        internal DbSet<ApplicableIngredient> Ingredients { get; set; }

        private readonly IConfiguration configuration;

        public RecipeGeneratorDbContext(
            IConfiguration configuration,
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.configuration = configuration;
            if (Database.IsRelational())
            {
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
        }
    }
}
