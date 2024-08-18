using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using System.Collections.ObjectModel;

namespace RecipeGenerator.ViewModels.List.Ingredients
{
    public class ListIngredientsViewModel : ObservableObject
    {
        private readonly ILogger<ListIngredientsViewModel> logger;
        private readonly IUnitOfWork unitOfWork;

        public ListIngredientsViewModel(ILogger<ListIngredientsViewModel> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }
        private ObservableCollection<GetAllApplicableIngredientsResponseItem> ingredients = new();
        public ObservableCollection<GetAllApplicableIngredientsResponseItem> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        private int pageNumber = 1;
        public int PageNumber
        {
            get => pageNumber;
            set => SetProperty(ref pageNumber, value);
        }

        private int pageSize = 10;
        public int PageSize
        {
            get => pageSize;
            set => SetProperty(ref pageSize, value);
        }

        private string filterString = default!;
        public string FilterString
        {
            get => filterString;
            set => SetProperty(ref filterString, value);
        }

        public async Task GetIngredientsAsync()
        {
            try
            {
                logger.LogInformation($"Getting ingredients...");
                logger.LogInformation($"Parameters:\r\npage number: {PageNumber};\r\npage size: {PageSize};\r\nfilter string: {FilterString}");
                GetAllApplicableIngredientsResponse? response = await unitOfWork.ApplicableIngredientRepository.GetAllAsync(PageSize, PageNumber -1, FilterString);
                if (response != null)
                {
                    Ingredients = new ObservableCollection<GetAllApplicableIngredientsResponseItem>(response.Items.Select(c => (GetAllApplicableIngredientsResponseItem)c));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetIngredientsAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task NextPage()
        {
            if (PageNumber < int.MaxValue)
            {
                PageNumber++;
                await GetIngredientsAsync();
            }
        }

        public async Task PreviousPage()
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                await GetIngredientsAsync();
            }
        }
    }
}
