using Microsoft.EntityFrameworkCore;
using RecipeGenerator.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Extenstions
{
    public static class DatabaseExtensions
    {
        public static void ChangeDatabase(
            this DbContext source, string culture)
        {
            try
            {
                source.Database.SetConnectionString($"Data Source=\"{Path.Combine(AppPaths.DataFolder, $"Recipe.{culture}.db")}\"");
                source.Database.EnsureCreated();
            }
            catch
            {
                throw;
            }
        }
    }
}
