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
            document.Info.Author = Environment.UserName;
            document.Info.Subject = recipe.Name;
            document.Info.Keywords = recipe.CourseType.ToString();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XRect rect = new XRect(0, 0, page.Width.Point, page.Height.Point);

            AddTitle(gfx, recipe.Name, rect);
            AddEstimatedTime(gfx, recipe.EstimatedTime, rect);
            AddPortions(gfx, recipe.Portions, rect);
            AddDescription(gfx, recipe.Description, rect);
            AddImage(gfx, recipe.Image, rect);
            AddIngredients(gfx, ingredients, rect);
            AddSteps(gfx, steps, rect);

            

            var saveDir = Path.Combine(AppPaths.DataFolder, "Saved recipes");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
            document.Save(saveFile);
        }

        private void AddTitle(XGraphics xGraphics, string title, XRect rect)
        {
            XFont font = new XFont("Verdana", 20, XFontStyleEx.Regular);

            xGraphics.DrawString(title, font, XBrushes.Black, new XPoint(30, 30));
        }

        private void AddEstimatedTime(XGraphics xGraphics, TimeSpan estimatedTime, XRect rect)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Italic);

            xGraphics.DrawString($"Estimated time: {estimatedTime.TotalMinutes.ToString()}", font, XBrushes.Black, new XPoint(30, 60));
        }

        private void AddPortions(XGraphics xGraphics, int portions, XRect rect)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Italic);

            xGraphics.DrawString($"Portions: {portions.ToString()}", font, XBrushes.Black, new XPoint(30, 90));
        }

        private void AddDescription(XGraphics xGraphics, string description, XRect rect)
        {
            XFont font = new XFont("Verdana", 14, XFontStyleEx.Regular);

            xGraphics.DrawString(description, font, XBrushes.Black, new XPoint(30, 120));
        }

        private void AddImage(XGraphics xGraphics, byte[] image, XRect rect) 
        {
            using MemoryStream memoryStream = new MemoryStream(image, 0, image.Length, false, true);
            var loadedImage = XImage.FromStream(memoryStream);
            xGraphics.DrawImage(loadedImage, 30, 150, loadedImage.PointWidth / 3, loadedImage.PointHeight / 3);
        }

        private void AddIngredients(XGraphics xGraphics, IEnumerable<GetAppliedIngredientResponse?> ingredients, XRect rect)
        {

        }

        private void AddSteps(XGraphics xGraphics, IEnumerable<GetStepResponse?> steps, XRect rect)
        {

        }
    }
}
