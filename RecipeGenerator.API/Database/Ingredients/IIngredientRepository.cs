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
        Task<GetIngredientDTO> GetByName(GetIngredientDTO getIngredientDTO);

        Task<GetIngredientDTO> GetById(GetIngredientDTO getIngredientDTO);

        Task<IEnumerable<GetIngredientDTO>> GetAll();

        IEnumerable<GetIngredientDTO> GetByType(GetIngredientDTO getIngredientDTO);

        Task Create(CreateIngredientDTO createIngredientDTO);

        Task Update(UpdateIngredientDTO updateIngredientDTO);

        Task Delete(DeleteIngredientDTO deleteIngredientDTO);
    }
}
