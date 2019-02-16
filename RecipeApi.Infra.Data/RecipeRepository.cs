using Microsoft.EntityFrameworkCore;
using RecipeApi.Domain;
using RecipeApi.Domain.Repository;
using RecipeApi.Infra.Data.Db;
using RecipeApi.Infra.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeApi.Infra.Data
{
    public class RecipeRepository : IRecipeRepository
    {

        private readonly DbContextOptions<RecipeContext> _options = new DbContextOptionsBuilder<RecipeContext>().UseInMemoryDatabase(databaseName: "RecipeContext").Options;

        public int CreateNewRecipe(string name, int portion, int calories)
        {
            using (RecipeContext context = new RecipeContext(_options))
            {
                var dto = new RecipeDTO { Name = name, Portion = portion, Calories = calories };
                context.Recipes.Add(dto);
                context.SaveChanges();
                return dto.Id;
            }
        }

        public List<Recipe> GetAllRecipe()
        {
            using (RecipeContext context = new RecipeContext(_options))
            {
                IQueryable<RecipeDTO> recipesDtn = from temp in context.Recipes select temp;
                var recipesDto = recipesDtn.ToList();

                IQueryable<IngredientDTO> ingredientsDtn = from temp in context.Ingredients select temp;
                var ingredientsDto = ingredientsDtn.ToList();

                IQueryable<PrepareMethodDTO> prepareMethodsDtn = from temp in context.PrepareMethods select temp;
                var pmsDto = prepareMethodsDtn.ToList();

                var result = new List<Recipe>();
                foreach (var recipeDto in recipesDto)
                {
                    var recipe = new Recipe
                    {
                        Id = recipeDto.Id,
                        Name = recipeDto.Name,
                        Portion = recipeDto.Portion,
                        Calories = recipeDto.Calories
                    };

                    recipe.Ingredients = ingredientsDto.Where(x => x.RecipeId == recipeDto.Id).Select(x => new Ingredient { Name = x.Name }).ToList();
                    recipe.PrepareMethod = pmsDto.Where(x => x.RecipeId == recipeDto.Id).Select(x => x.Description).FirstOrDefault();
                    result.Add(recipe);
                }
                return result;
            }
        }

        public Recipe GetRecipeById(int id)
        {
            using (RecipeContext context = new RecipeContext(_options))
            {
                var recipeDto = context.Recipes.Where(x => x.Id == id).FirstOrDefault();
                var result = new Recipe();

                result.Id = recipeDto.Id;
                result.Name = recipeDto.Name;
                result.Portion = recipeDto.Portion;
                result.Calories = recipeDto.Calories;


                result.Ingredients = context.Ingredients.Where(x => x.RecipeId == id).Select(x => new Ingredient { Name = x.Name }).ToList();
                result.PrepareMethod = context.PrepareMethods.Where(x => x.RecipeId == id).Select(x => x.Description).FirstOrDefault();

                return result;
            }
        }

        public void InsertIngredient(int recipeId, List<Ingredient> ingredients)
        {
            using (RecipeContext context = new RecipeContext(_options))
            {
                foreach (var ingredient in ingredients)
                {
                    var dto = new IngredientDTO { RecipeId = recipeId, Name = ingredient.Name };
                    context.Ingredients.Add(dto);
                    context.SaveChanges();

                }
            }
        }

        public void InsertPrepareMethod(int recipeId, string description)
        {
            using (RecipeContext context = new RecipeContext(_options))
            {
                var dto = new PrepareMethodDTO { RecipeId = recipeId, Description = description };
                context.PrepareMethods.Add(dto);
                context.SaveChanges();
            }
        }

    }
}
