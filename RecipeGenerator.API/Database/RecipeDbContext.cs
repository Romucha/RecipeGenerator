using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Models;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    internal class RecipeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<IIngredient> Ingredients { get; set; }

        private readonly IConfiguration configuration;
        public RecipeDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        private void seedCereal(ModelBuilder modelBuilder) 
        {
            
        }
    }
}
