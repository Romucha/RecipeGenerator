﻿using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.API.Database;
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
            services.AddSqlite<RecipeDbContext>("Data Source=Recipe.db;Cache=Shared");
            return services;
        }
    }
}
