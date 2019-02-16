using RecipeApi.Domain;
using RecipeApi.Service.Model;
using RecipeApi.Service.Models;
using RecipeApi.Service.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Service
{
    public interface IRecipeService
    {
        Result<CreateNewRecipeResult> CreateNewRecipe(CreateNewRecipeInput input);
        Result<bool> InsertIngredientsToRecipe(int id, InsertIngredientsInput input);
        Result<bool> InsertPrepareMethodToRecipe(int id, InsertPrepareMethodInput input);
        Result<List<Recipe>> GetAllRecipes();
        Result<Recipe> GetRecipeById(int id);
    }
}
