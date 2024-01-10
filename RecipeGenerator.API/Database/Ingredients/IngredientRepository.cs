using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeDbContext dbContext;
        private readonly IMapper mapper;
        internal IngredientRepository(RecipeDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Create(CreateIngredientDTO createIngredientDTO)
        {
            var ingredient = mapper.Map<Ingredient>(createIngredientDTO);
            await dbContext.Ingredients.AddAsync(ingredient);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(DeleteIngredientDTO deleteIngredientDTO)
        {
            var ingredient = mapper.Map<Ingredient>(deleteIngredientDTO);
            dbContext.Ingredients.Remove(ingredient);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetIngredientDTO>> GetAll()
        {
            var ingredients = await Task.FromResult(dbContext.Ingredients.AsNoTracking());
            return ingredients.Select(c => mapper.Map<GetIngredientDTO>(c));
        }

        public async Task<GetIngredientDTO> GetByName(string name)
        {
            var ingredient = await dbContext.Ingredients.FirstOrDefaultAsync(x => x.Name == name);
            return mapper.Map<GetIngredientDTO>(ingredient);
        }

        public IEnumerable<GetIngredientDTO> GetByType(IngredientType type)
        {
            var ingredients = dbContext.Ingredients.Where(c => c.IngredientType == type).AsNoTracking();
            return ingredients.Select(c => mapper.Map<GetIngredientDTO>(c));
        }

        public async Task Update(UpdateIngredientDTO updateIngredientDTO)
        {
            updateIngredientDTO.UpdatedAt = DateTime.Now;
            var ingredient = mapper.Map<Ingredient>(updateIngredientDTO);
            dbContext.Ingredients.Update(ingredient);
            await dbContext.SaveChangesAsync();
        }
    }
}
