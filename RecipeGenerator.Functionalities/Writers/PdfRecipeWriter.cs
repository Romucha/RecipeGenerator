using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using RecipeGenerator.DTO.Recipes.Responses;
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
        public void Write(GetRecipeResponse recipe)
        {

            PdfDocument document = new PdfDocument();

            document.Info.Title = recipe.Name;

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyleEx.Italic);

            gfx.DrawString(recipe.Description, font, XBrushes.Black, new XRect(new XPoint(0,0), new XPoint(page.Width, page.Height)), XStringFormats.Center);

            var saveDir = Path.Combine(AppPaths.DataFolder, "Saved recipes");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            var saveFile = Path.Combine(saveDir, $"{recipe.Name.Replace(' ', '-')}_{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}.pdf");
            document.Save(saveFile);
        }
    }
}
