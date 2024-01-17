using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public class RecipeDbContext : DbContext
    {
        internal DbSet<Recipe> Recipes { get; set; }

        internal DbSet<Ingredient> Ingredients { get; set; }

        private readonly IConfiguration configuration;
        private readonly IIngredientGetter ingredientGetter;
        private readonly IMapper mapper;

        public RecipeDbContext(IConfiguration configuration, IIngredientGetter ingredientGetter, IMapper mapper, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.configuration = configuration;
            this.ingredientGetter = ingredientGetter;
            this.mapper = mapper;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(ingredientGetter.Get().Select(c => mapper.Map<Ingredient>(c)));
            modelBuilder.Entity<AppliedIngredient>().Property(e => e.Id).ValueGeneratedOnUpdateSometimes();
        }
    }
}
