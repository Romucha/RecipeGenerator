using AutoMapper;
using RecipeGenerator.API.DTO.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    internal class IngredientFactory : IIngredientFactory
    {
        private readonly IMapper mapper;
        public IngredientFactory(IMapper mapper) 
        {
            this.mapper = mapper;
        }
        public Ingredient Create(string name, string description, Uri link, byte[] image, IngredientType ingredientType)
        {
            return new Ingredient()
            { 
                Id = Guid.NewGuid(),
                Name = name, 
                Description = description, 
                Link = link, 
                IngredientType = ingredientType,
                Image = image
            };
        }

        public Ingredient CreateFromDTO(CreateIngredientDTO createIngredientDTO)
        {
            return mapper.Map<Ingredient>(createIngredientDTO);
        }
    }
}
