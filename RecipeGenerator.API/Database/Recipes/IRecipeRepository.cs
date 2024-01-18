using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Recipes
{
    public interface IRecipeRepository
    {
        Task<GetRecipeDTO> GetByName(GetRecipeDTO getRecipeDTO);
        Task<GetRecipeDTO> GetById(GetRecipeDTO getRecipeDTO);

        Task<IEnumerable<GetRecipeDTO>> GetAll();

        Task Create(CreateRecipeDTO createRecipeDTO);

        Task Update(UpdateRecipeDTO updateRecipeDTO);

        Task Delete(DeleteRecipeDTO deleteRecipeDTO);
    }
}
