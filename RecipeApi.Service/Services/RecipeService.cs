using System;
using System.Collections.Generic;
using System.Linq;
using RecipeApi.Domain;
using RecipeApi.Domain.Repository;
using RecipeApi.Service.Model;
using RecipeApi.Service.Models;
using RecipeApi.Service.Models.Input;

namespace RecipeApi.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public Result<CreateNewRecipeResult> CreateNewRecipe(CreateNewRecipeInput input)
        {
            try
            {
                var recipeId = _recipeRepository.CreateNewRecipe(input.Name, input.Portion, input.Calories);
                var response = new CreateNewRecipeResult { Id = recipeId };
                return Result<CreateNewRecipeResult>.CreateSuccessResult(response);
            }
            catch (Exception ex)
            {
                return Result<CreateNewRecipeResult>.CreateErrorResult(ex);
            }
        }

        public Result<List<Recipe>> GetAllRecipes()
        {
            try
            {
                var recipes = _recipeRepository.GetAllRecipe();
                return Result<List<Recipe>>.CreateSuccessResult(recipes);
            }
            catch (Exception ex)
            {
                return Result<List<Recipe>>.CreateErrorResult(ex);
            }
        }

        public Result<Recipe> GetRecipeById(int id)
        {
            try
            {
                var recipe = _recipeRepository.GetRecipeById(id);
                return Result<Recipe>.CreateSuccessResult(recipe);
            }
            catch (Exception ex)
            {
                return Result<Recipe>.CreateErrorResult(ex);
            }
        }

        public Result<bool> InsertIngredientsToRecipe(int id, InsertIngredientsInput input)
        {
            try
            {
                var ingredients = input.Ingredients.Select(x => new Ingredient { Name = x }).ToList();
                _recipeRepository.InsertIngredient(id, ingredients);
                return Result<bool>.CreateSuccessResult(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.CreateErrorResult(ex);
            }
        }

        public Result<bool> InsertPrepareMethodToRecipe(int id, InsertPrepareMethodInput input)
        {
            try
            {
                _recipeRepository.InsertPrepareMethod(id, input.Description);
                return Result<bool>.CreateSuccessResult(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.CreateErrorResult(ex);
            }
        }
    }
}
