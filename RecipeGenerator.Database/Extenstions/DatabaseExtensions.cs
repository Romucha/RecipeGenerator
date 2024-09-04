using Microsoft.EntityFrameworkCore;
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
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
                if (!Directory.Exists(dbPath))
                {
                    Directory.CreateDirectory(dbPath);
                }
                source.Database.SetConnectionString($"Data Source=\"{dbPath}/Recipe.{culture}.db\"");
            }
            catch
            {
                throw;
            }
        }
    }
}
