using Microsoft.Extensions.Logging;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Writers
{
    public class PdfRecipeWriter : IRecipeWriter
    {
        private readonly ILogger<PdfRecipeWriter> logger;

        public PdfRecipeWriter(ILogger<PdfRecipeWriter> logger)
        {
            this.logger = logger;
        }

        public string Write(GetRecipeResponse recipe, IEnumerable<GetAppliedIngredientResponse?> ingredients, IEnumerable<GetStepResponse?> steps)
        {
            try
            {
                var saveDir = AppPaths.SavedRecipesFolder;
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);
                var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.Transparent);
                        page.DefaultTextStyle(x => x.FontSize(14).FontFamily("Arial"));

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(10);
                                x.Item().Text(recipe.Name).FontSize(16).ExtraBold();

                                x.Item().Text($"Estimated time: {recipe.EstimatedTime} min").FontSize(12).Italic();
                                x.Item().Text($"Portions: {recipe.Portions}").FontSize(12).Italic();

                                x.Item().Text(recipe.Description);

                                x.Item().Width(PageSizes.A8.Width).Image(recipe.Image).FitWidth();

                                x.Item().Text("Ingredients").ExtraBold();
                                for (int i = 0; i < ingredients.Count(); ++i)
                                {
                                    var ingr = ingredients.ElementAt(i);
                                    if (ingr != null)
                                    {
                                        x.Item().Row(x =>
                                        {
                                            x.Spacing(5);
                                            x.AutoItem().Text($"{i + 1}.");
                                            x.RelativeItem().Text(ingr.Name);
                                        });
                                    }
                                }

                                x.Item().Text("Steps").ExtraBold();
                                for (int i = 0; i < steps.Count(); ++i)
                                {
                                    var step = steps.ElementAt(i);
                                    if (step != null)
                                    {
                                        x.Item().Row(x =>
                                        {
                                            x.Spacing(5);
                                            x.AutoItem().Text($"{i + 1}.");
                                            x.RelativeItem().Column(y =>
                                            {
                                                y.Item().Text(step.Name).Bold();
                                                y.Item().Text(step.Description);
                                                //if (step.Photos.Any())
                                                //{
                                                //    for (int j = 0; j <= step.Photos.Count(); ++j)
                                                //    {
                                                //        y.Item().Width(PageSizes.A8.Width).Image(step.Photos[j]).FitWidth();
                                                //    }
                                                //}
                                            });
                                        });
                                    }
                                }
                            });
                    });
                })
                    .GeneratePdf(saveFile);
                return saveFile;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, nameof(Write));
                throw;
            }
        }
    }
}
