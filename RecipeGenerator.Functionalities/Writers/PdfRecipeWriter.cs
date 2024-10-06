using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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

            PdfDocument document = new PdfDocument();

            document.Info.Title = recipe.Name;

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            AddTitle(gfx, recipe.Name);
            AddEstimatedTime(gfx, recipe.EstimatedTime);
            AddPortions(gfx, recipe.Portions);
            AddImage(gfx, recipe.Image);
            AddDescription(gfx, recipe.Description);
            AddIngredients(gfx, ingredients);
            AddSteps(gfx, steps);

            XFont font = new XFont("Verdana", 20, XFontStyleEx.Italic);

            gfx.DrawString(recipe.Description, font, XBrushes.Black, new XRect(new XPoint(0,0), new XPoint(page.Width, page.Height)), XStringFormats.TopLeft);
            
            using MemoryStream memoryStream = new MemoryStream(recipe.Image, 0, recipe.Image.Length, false, true);
            gfx.DrawImage(XImage.FromStream(memoryStream), new XPoint(0, 0));

            var saveDir = Path.Combine(AppPaths.DataFolder, "Saved recipes");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
            document.Save(saveFile);
        }

        private void AddTitle(XGraphics xGraphics, string title)
        {

        }

        private void AddEstimatedTime(XGraphics xGraphics, TimeSpan estimatedTime)
        {

        }

        private void AddPortions(XGraphics xGraphics, int portions)
        {

        }

        private void AddImage(XGraphics xGraphics, byte[] image) 
        {
        }

        private void AddDescription(XGraphics xGraphics, string description)
        {
        }

        private void AddIngredients(XGraphics xGraphics, IEnumerable<GetAppliedIngredientResponse?> ingredients)
        {

        }

        private void AddSteps(XGraphics xGraphics, IEnumerable<GetStepResponse?> steps)
        {

        }
    }
}
