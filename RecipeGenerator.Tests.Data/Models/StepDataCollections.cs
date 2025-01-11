using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class StepDataCollections
    {
        public static List<Step> Normal => new()
        { 
            new()
            {
                Id = 1,
                Name = $"{nameof(Normal)}_1",
                Description = $"{nameof(Normal)}_1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                Index = 1,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 2,
                Name = $"{nameof(Normal)}_2",
                Description = $"{nameof(Normal)}_2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                Index = 2,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 3,
                Name = $"{nameof(Normal)}_3",
                Description = $"{nameof(Normal)}_3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                Index = 3,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 4,
                Name = $"{nameof(Normal)}_4",
                Description = $"{nameof(Normal)}_4",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 2,
                Index = 1,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 5,
                Name = $"{nameof(Normal)}_5",
                Description = $"{nameof(Normal)}_5",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 2,
                Index = 2,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 6,
                Name = $"{nameof(Normal)}_6",
                Description = $"{nameof(Normal)}_6",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 2,
                Index = 3,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 7,
                Name = $"{nameof(Normal)}_7",
                Description = $"{nameof(Normal)}_7",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 3,
                Index = 1,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 8,
                Name = $"{nameof(Normal)}_8",
                Description = $"{nameof(Normal)}_8",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 3,
                Index = 2,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
            new()
            {
                Id = 9,
                Name = $"{nameof(Normal)}_9",
                Description = $"{nameof(Normal)}_9",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 3,
                Index = 3,
                Photos = new(){ Properties.Resources.StepNormal, Properties.Resources.StepNormal }
            },
        };
    }
}
