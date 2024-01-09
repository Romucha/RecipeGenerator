using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Ingredients
{
    public interface IIngredientRepository
    {
        Task<GetIngredientDTO> GetByName(string name);

        Task<IEnumerable<GetIngredientDTO>> GetAll();

        IEnumerable<GetIngredientDTO> GetByType(IngredientType type);

        Task Create(CreateIngredientDTO createIngredientDTO);

        Task Update(UpdateIngredientDTO updateIngredientDTO);

        Task Delete(DeleteIngredientDTO deleteIngredientDTO);
    }
}
