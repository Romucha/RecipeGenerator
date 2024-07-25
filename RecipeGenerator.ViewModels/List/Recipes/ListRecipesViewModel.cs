using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    private ObservableCollection<GetAllRecipeResponse> recipes = new();
    public ObservableCollection<GetAllRecipeResponse> Recipes
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
            GetAllRecipesResponse? response = await unitOfWork.GetAllAsync<Recipe, GetAllRecipesRequest, GetAllRecipesResponse, GetAllRecipeResponse>(request);
            if (response != null)
            {
                Recipes = new ObservableCollection<GetAllRecipeResponse>(response.Items.Select(c => (GetAllRecipeResponse)c));
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

    public async Task Seed(CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < 40; ++i)
        {
            var response = await unitOfWork.CreateAsync<Recipe, CreateRecipeRequest, CreateRecipeResponse>(new(), cancellationToken);
            if (response != null)
            {
                UpdateRecipeRequest request = new()
                {
                    Id = response.Id,
                    Name = $"Recipe №{i}",
                    Description = $"Recipe №{i} description"
                };
                await unitOfWork.SaveChangesAsync(cancellationToken);
                await unitOfWork.UpdateAsync<Recipe, UpdateRecipeRequest, UpdateRecipeResponse>(request, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
