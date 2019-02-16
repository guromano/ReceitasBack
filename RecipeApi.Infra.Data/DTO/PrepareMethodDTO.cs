using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Infra.Data.DTO
{
    public class PrepareMethodDTO
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }

    }
}
