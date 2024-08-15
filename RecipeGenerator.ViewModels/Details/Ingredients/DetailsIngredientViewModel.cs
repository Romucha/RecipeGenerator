using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;

namespace RecipeGenerator.ViewModels.Details.Ingredients
{
    public class DetailsIngredientViewModel : ObservableObject
    {
        private readonly ILogger<DetailsIngredientViewModel> logger;
        private readonly IUnitOfWork unitOfWork;

        public DetailsIngredientViewModel(ILogger<DetailsIngredientViewModel> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }
        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get => createdAt;
            set => SetProperty(ref createdAt, value);
        }
        private DateTime updatedAt;
        public DateTime UpdatedAt
        {
            get => updatedAt;
            set => SetProperty(ref updatedAt, value);
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private Uri link = default!;
        public Uri Link
        {
            get => link;
            set => SetProperty(ref link, value);
        }

        private IngredientType ingredientType;
        public IngredientType IngredientType
        {
            get => ingredientType;
            set => SetProperty(ref ingredientType, value);
        }

        private string image = default!;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public async Task GetIngredientAsync(Guid id)
        {
            try
            {
                logger.LogInformation($"Getting ingredient with id: {id}");
                GetApplicableIngredientRequest request = new GetApplicableIngredientRequest()
                {
                    Id = id,
                };
                GetApplicableIngredientResponse? response = await unitOfWork.GetAsync<ApplicableIngredient, GetApplicableIngredientRequest, GetApplicableIngredientResponse>(request);
                if (response != null)
                {
                    Name = response.Name;
                    Description = response.Description;
                    CreatedAt = response.CreatedAt;
                    UpdatedAt = response.UpdatedAt;
                    Link = response.Link;
                    Image = Convert.ToBase64String(response.Image);
                    IngredientType = (IngredientType)response.IngredientType;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetIngredientAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
