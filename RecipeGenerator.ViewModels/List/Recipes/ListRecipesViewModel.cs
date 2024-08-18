using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.Models.Recipes;
using System.Collections.ObjectModel;
namespace RecipeGenerator.ViewModels.List.Recipes;
public class ListRecipesViewModel : ObservableObject
{
    private readonly ILogger<ListRecipesViewModel> logger;
    private readonly IUnitOfWork unitOfWork;

    public ListRecipesViewModel(ILogger<ListRecipesViewModel> logger, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.unitOfWork = unitOfWork;
    }

    private ObservableCollection<GetAllRecipesResponseItem> recipes = new();
    public ObservableCollection<GetAllRecipesResponseItem> Recipes
    {
        get => recipes;
        set => SetProperty(ref recipes, value);
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

    public async Task GetRecipesAsync()
    {
        try
        {
            logger.LogInformation($"Getting recipes...");
            logger.LogInformation($"Parameters:\r\npage number: {PageNumber};\r\npage size: {PageSize};\r\nfilter string: {FilterString}");
            GetAllRecipesRequest request = new()
            {
                Filter = FilterString,
                PageNumber = PageNumber - 1,
                PageSize = PageSize
            };
            GetAllRecipesResponse? response = await unitOfWork.RecipeRepository.GetAllAsync(PageSize, PageNumber - 1, FilterString);
            if (response != null)
            {
                Recipes = new ObservableCollection<GetAllRecipesResponseItem>(response.Items.Select(c => (GetAllRecipesResponseItem)c).OrderByDescending(c => c.UpdatedAt));
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(GetRecipesAsync));
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
            await GetRecipesAsync();
        }
    }

    public async Task PreviousPage()
    {
        if (PageNumber > 1)
        {
            PageNumber--;
            await GetRecipesAsync();
        }
    }

    public async Task DeleteRecipeAsync(Guid id)
    {
        try
        {
            logger.LogInformation($"Deleting recipe {id}...");
            var item = Recipes.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Recipes.Remove(item);

                DeleteRecipeResponse? deleteRecipeResponse = await unitOfWork.RecipeRepository.DeleteAsync(id);
                if (deleteRecipeResponse != null)
                {
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(DeleteRecipeAsync));
        }
        finally
        {
            logger.LogInformation("Done.");
        }
    }
}
