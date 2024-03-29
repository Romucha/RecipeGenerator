﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services) 
        {
            services.AddTransient<IIngredientFactory, IngredientFactory>();
            services.AddTransient<IIngredientGetter, IngredientGetter>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();

            services.AddTransient<IRecipeFactory, RecipeFactory>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            services.AddTransient<IStepFactory, StepFactory>();

            services.AddAutoMapper(typeof(MapperInitializer));

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
            if (!Directory.Exists(dbPath)) {
                Directory.CreateDirectory(dbPath);
            }
            services.AddSqlite<RecipeDbContext>($"Data Source={dbPath}\\Recipe.db");

            return services;
        }
    }
}
