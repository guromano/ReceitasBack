using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Service.Models.Input
{
    public class CreateNewRecipeInput
    {
        public string Name { get; set; }
        public int Portion { get; set; }
        public int Calories { get; set; }
    }
}
