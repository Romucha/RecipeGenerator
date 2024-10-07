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

            AddTitle(gfx, recipe.Name, page.Width, page.Height);
            AddEstimatedTime(gfx, recipe.EstimatedTime, page.Width, page.Height);
            AddPortions(gfx, recipe.Portions, page.Width, page.Height);
            AddImage(gfx, recipe.Image);
            AddDescription(gfx, recipe.Description, page.Width, page.Height);
            AddIngredients(gfx, ingredients);
            AddSteps(gfx, steps);

            

            var saveDir = Path.Combine(AppPaths.DataFolder, "Saved recipes");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
            document.Save(saveFile);
        }

        private void AddTitle(XGraphics xGraphics, string title, double width, double height)
        {
            XFont font = new XFont("Verdana", 20, XFontStyleEx.Regular);

            xGraphics.DrawString(title, font, XBrushes.Black, new XRect(new XPoint(0, 0), new XPoint(width, height)), XStringFormats.TopLeft);
        }

        private void AddEstimatedTime(XGraphics xGraphics, TimeSpan estimatedTime, double width, double height)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Italic);

            xGraphics.DrawString(estimatedTime.TotalMinutes.ToString(), font, XBrushes.Black, new XRect(new XPoint(0, 0), new XPoint(width, height)), XStringFormats.TopLeft);
        }

        private void AddPortions(XGraphics xGraphics, int portions, double width, double height)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Italic);

            xGraphics.DrawString(portions.ToString(), font, XBrushes.Black, new XRect(new XPoint(0, 0), new XPoint(width, height)), XStringFormats.TopLeft);
        }

        private void AddImage(XGraphics xGraphics, byte[] image) 
        {
            using MemoryStream memoryStream = new MemoryStream(image, 0, image.Length, false, true);
            var loadedImage = XImage.FromStream(memoryStream);
            xGraphics.DrawImage(loadedImage, 0, 0, loadedImage.PointHeight / 2, loadedImage.PointHeight / 2);
        }

        private void AddDescription(XGraphics xGraphics, string description, double width, double height)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Regular);

            xGraphics.DrawString(description, font, XBrushes.Black, new XRect(new XPoint(0, 0), new XPoint(width, height)), XStringFormats.TopLeft);
        }

        private void AddIngredients(XGraphics xGraphics, IEnumerable<GetAppliedIngredientResponse?> ingredients)
        {

        }

        private void AddSteps(XGraphics xGraphics, IEnumerable<GetStepResponse?> steps)
        {

        }
    }
}
