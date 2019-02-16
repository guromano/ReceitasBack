using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Domain.Repository
{
    public interface IRecipeRepository
    {
        int CreateNewRecipe(string name, int portion, int calories);
        void InsertIngredient(int recipeId, List<Ingredient> ingredients);
        void InsertPrepareMethod(int recipeId, string description);
        List<Recipe> GetAllRecipe();
        Recipe GetRecipeById(int id);
    }
}
