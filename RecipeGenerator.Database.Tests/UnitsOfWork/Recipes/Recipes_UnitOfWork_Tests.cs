using Microsoft.EntityFrameworkCore;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork.Recipes
{
    public class Recipes_UnitOfWork_Tests : UnitOfWork_Tests_Base
        <
            Recipe,
            CreateRecipeRequest,
            CreateRecipeResponse,
            DeleteRecipeRequest,
            DeleteRecipeResponse,
            GetAllRecipesRequest,
            GetAllRecipeResponse,
            GetAllRecipesResponse,
            GetRecipeRequest,
            GetRecipeResponse,
            UpdateRecipeRequest,
            UpdateRecipeResponse
        >
    {
        private IEnumerable<ApplicableIngredient> _applicableIngredients;
        private IEnumerable<AppliedIngredient> _appliedIngredients;
        private IEnumerable<Step> _steps;

        public Recipes_UnitOfWork_Tests() : base()
        {
            var applicableIngredients = new List<ApplicableIngredient>()
            {
                new ApplicableIngredient(),
                new ApplicableIngredient(),
                new ApplicableIngredient(),
                new ApplicableIngredient()
            };
            dbContext.AddRange(applicableIngredients);

            var appliedIngredients = new List<AppliedIngredient>()
            {
                new AppliedIngredient(),
                new AppliedIngredient(),
                new AppliedIngredient(),
                new AppliedIngredient()
            };

            for (int i = 0; i < appliedIngredients.Count; ++i)
            {
                appliedIngredients[i].IngredientId = applicableIngredients[i].Id;
            }
            dbContext.AddRange(appliedIngredients);

            var steps = new List<Step>()
            {
                new Step(),
                new Step(),
                new Step(),
            };
            dbContext.AddRange(steps);

            dbContext.SaveChanges();
            dbContext.ChangeTracker.Clear();

            _applicableIngredients = dbContext.Set<ApplicableIngredient>().AsNoTracking();
            _appliedIngredients = dbContext.Set<AppliedIngredient>().AsNoTracking();
            _steps = dbContext.Set<Step>().AsNoTracking();
        }

        protected override void CompareEntities<EditRequest, EditResponse>(EditRequest req, EditResponse res)
        {
            var request = req as UpdateRecipeRequest;
            var response = res as UpdateRecipeResponse;
            if (response is null || request is null)
            {
                throw new NullReferenceException();
            }
            Assert.Equal(request.Id, response.Id);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Description, response.Description);
            Assert.Equal(request.Image, response.Image);
            Assert.Equal(request.EstimatedTime, response.EstimatedTime);
            Assert.Equal(request.Portions, response.Portions);
            Assert.NotNull(response.Ingredients);
            Assert.NotEmpty(response.Ingredients);
            foreach (var ingredient in response.Ingredients)
            {
                Assert.Contains(request.Ingredients!, c => c!.Id == ingredient.Id);
            }
            Assert.NotNull(response.Steps);
            Assert.NotEmpty(response.Steps);
            foreach (var step in response.Steps)
            {
                Assert.Contains(request.Steps!, c => c!.Id == step.Id);
            }
        }

        protected override void EditRequest<EditRequest>(EditRequest req)
        {
            var request = req as UpdateRecipeRequest;
            if (request is null)
                throw new NullReferenceException();
            request.Name = nameof(EditRequest);
            request.Description = nameof(EditRequest);
            request.Image = nameof(EditRequest);
            request.EstimatedTime = TimeSpan.FromMinutes(10);
            request.Portions = 10;
            request.Ingredients = _appliedIngredients.Select(c => new UpdateAppliedIngredientRequest()
            {
                Id = c.Id,
                IngredientId = c.IngredientId,
            }).ToList()!;
            request.Steps = _steps.Select(c => new UpdateStepRequest()
            {
                Id =c.Id,
                Name = c.Name,
                Description = c.Description,
                Index = c.Index,
                Photos = c.Photos,
            }).ToList()!;
        }
    }
}
