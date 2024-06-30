using AutoMapper;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.DTO.AppliedIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.DTO.Ingredients;

namespace RecipeGenerator.Functionalities.Factories.Ingredients
{
    internal class ApplicableIngredientFactory
    {
        private readonly IMapper mapper;
        public ApplicableIngredientFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public ApplicableIngredient Create(string name, string description, Uri link, string image, IngredientType ingredientType)
        {
            return new()
            {
                Name = name,
                Description = description,
                Link = link,
                IngredientType = ingredientType,
                Image = image
            };
        }

        public ApplicableIngredient CreateFromDTO(CreateApplicableIngredientDTO createIngredientDTO)
        {
            return mapper.Map<ApplicableIngredient>(createIngredientDTO);
        }
    }
}
