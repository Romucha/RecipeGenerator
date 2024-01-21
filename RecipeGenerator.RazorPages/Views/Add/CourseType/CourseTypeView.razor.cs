﻿using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.CourseType
{
    public partial class CourseTypeView
    {
        [CascadingParameter]
        public AddVM AddVM { get; set; }
    }
}