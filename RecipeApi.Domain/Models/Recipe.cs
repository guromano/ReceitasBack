using System;
using System.Collections.Generic;

namespace RecipeApi.Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Portion { get; set; }

        public int Calories { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public string PrepareMethod { get; set; }
    }
}
