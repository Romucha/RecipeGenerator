using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.ViewModels.Create.Ingredients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Create.Recipes
{
    public class EditStepViewModel : ObservableObject
    {
        private readonly ILogger<EditStepViewModel> logger;
        private readonly IUnitOfWork unitOfWork;

        public EditStepViewModel(ILogger<EditStepViewModel> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        private string name = default!;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description = default!;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private int index;
        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

        private ObservableCollection<byte[]> photos = new();
        public ObservableCollection<byte[]> Photos
        {
            get => photos;
            set => SetProperty(ref photos, value);
        }

        public async Task EditStepAsync(Guid stepId, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Edititng step {stepId}...");
                UpdateStepRequest request = new UpdateStepRequest()
                {
                    Id = stepId,
                    Name = Name,
                    Description = Description,
                    Index = Index,
                    Photos = Photos.ToList(),
                };
                UpdateStepResponse? response = await unitOfWork.UpdateAsync<Step, UpdateStepRequest, UpdateStepResponse>(request, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(EditStepAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
