using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Infra.Data.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Portion { get; set; }

        public int Calories { get; set; }

    }
}
