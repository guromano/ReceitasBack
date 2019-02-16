using Microsoft.Extensions.DependencyInjection;
using Moq;
using RecipeApi.Domain;
using RecipeApi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Tests
{
    public static class RepositoryMock
    {
        public static void Mock(IServiceCollection services, string recipeName, int portion, int calories)
        {
            var mock = new Mock<IRecipeRepository>();
            mock.Setup(x => x.CreateNewRecipe(recipeName, portion, calories)).Returns(1);
            mock.Setup(x => x.GetAllRecipe())
                .Returns(new List<Recipe> { new Recipe { Id = 1, Name = recipeName, Portion = portion, Calories = calories, PrepareMethod = "Test method", Ingredients = new List<Ingredient> { new Ingredient { Name = "IngredientTest" } } } });
            mock.Setup(x => x.GetRecipeById(1))
                .Returns(new Recipe { Id = 1, Name = recipeName, Portion = portion, Calories = calories, PrepareMethod = "Test method", Ingredients = new List<Ingredient> { new Ingredient { Name = "IngredientTest" } } });
            services.AddTransient(provider => mock.Object);
        }
    }
}
