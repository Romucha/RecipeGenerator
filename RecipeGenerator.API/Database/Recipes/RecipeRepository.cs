using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext recipeDbContext;
        private readonly IMapper mapper;

        public RecipeRepository(RecipeDbContext recipeDbContext, IMapper mapper)
        {
            this.recipeDbContext = recipeDbContext;
            this.mapper = mapper;
        }

        public async Task Create(CreateRecipeDTO createRecipeDTO)
        {
            var recipe = mapper.Map<Recipe>(createRecipeDTO);
            await recipeDbContext.Recipes.AddAsync(recipe);
            await recipeDbContext.SaveChangesAsync();
        }

        public async Task Delete(DeleteRecipeDTO deleteRecipeDTO)
        {
            var recipe = mapper.Map<Recipe>(deleteRecipeDTO);

            recipeDbContext.Recipes.Remove(recipe);
            await recipeDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetRecipeDTO>> GetAll()
        {
            return (await Task.FromResult(recipeDbContext.Recipes.AsNoTracking())).Select(c => mapper.Map<GetRecipeDTO>(c));
        }

        public async Task<GetRecipeDTO> GetById(Guid id)
        {
            var recipe = await recipeDbContext.Recipes.FindAsync(id);
            return mapper.Map<GetRecipeDTO>(recipe);
        }

        public async Task<GetRecipeDTO> GetByName(string name)
        {
            var recipe = await recipeDbContext.Recipes.FirstOrDefaultAsync(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            return mapper.Map<GetRecipeDTO>(recipe);
        }

        public async Task Update(UpdateRecipeDTO updateRecipeDTO)
        {
            updateRecipeDTO.UpdatedAt = DateTime.Now;
            var newrecipe = mapper.Map<Recipe>(updateRecipeDTO);
            var oldrecipe = await recipeDbContext.Recipes.FindAsync(newrecipe.Id);
            oldrecipe.CopyFromSource(newrecipe);
            
            await recipeDbContext.SaveChangesAsync();
        }
    }
}
