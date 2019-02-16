using Microsoft.EntityFrameworkCore;
using RecipeApi.Infra.Data.Db;
using RecipeApi.Infra.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.CrossCutting.Db
{
    public static class RecipeExamplesSet
    {
        public static void SetExamples()
        {
            var options = new DbContextOptionsBuilder<RecipeContext>().UseInMemoryDatabase(databaseName: "RecipeContext").Options;
            using (RecipeContext context = new RecipeContext(options))
            {
                context.Recipes.Add(new RecipeDTO { Name = "Bolo de cenoura", Portion = 5, Calories = 350 });
     
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Farinha" });
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Ovo" });
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Açucar" });
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Cenoura" });
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Leite" });
                context.Ingredients.Add(new IngredientDTO { RecipeId = 1, Name = "Chocolate" });

                context.PrepareMethods.Add(new PrepareMethodDTO { RecipeId = 1, Description = "Bater no liquidificador a cenoura com o óleo. Acrescentar os ovos, o açúcar, a farinha e o fermento. Coloque a massa em uma forma untada e polvilhada. Leve para assar em forno 180ºC por 30 a 40 minutos. Misture todos os ingredientes e leve ao fogo até ferver. Despeje sobre o bolo ainda quente." });
                context.SaveChanges();
            }
        }
    }
}
