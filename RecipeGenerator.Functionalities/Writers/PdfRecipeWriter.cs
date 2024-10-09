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
        public void Write(GetRecipeResponse recipe, IEnumerable<GetAppliedIngredientResponse?> ingredients, IEnumerable<GetStepResponse?> steps)
        {
            var saveDir = Path.Combine(AppPaths.DataFolder, "Saved recipes");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text(recipe.Name)
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text(recipe.Description);
                            x.Item().Image(recipe.Image);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
                .GeneratePdf(saveFile);
        }
    }
}
