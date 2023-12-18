using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public class RecipeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        private readonly IConfiguration configuration;
        private readonly IngredientGetter ingredientGetter;

        public RecipeDbContext(IConfiguration configuration, IngredientGetter ingredientGetter, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.configuration = configuration;
            this.ingredientGetter = ingredientGetter;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(ingredientGetter.Get());
        }
    }
}
