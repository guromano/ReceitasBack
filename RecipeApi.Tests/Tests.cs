using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RecipeApi.Domain;
using RecipeApi.Domain.Repository;
using RecipeApi.Infra.Data;
using RecipeApi.Infra.Data.Db;
using RecipeApi.Service;
using RecipeApi.Service.Models.Input;
using RecipeApi.Tests;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private readonly IServiceCollection _services = new ServiceCollection();

        [SetUp]
        public void Setup()
        {
            _services.AddTransient<IRecipeService, RecipeService>();
            _services.AddTransient<IRecipeRepository, RecipeRepository>();
            _services.AddDbContext<RecipeContext>(opt => opt.UseInMemoryDatabase(databaseName: "RecipeContext"));
        }

        [Test]
        public void Should_create_recipe()
        {
            var testRecipe = new Recipe
            {
                Name = "Teste",
                Calories = 100,
                Portion = 1,
                Ingredients = new List<Ingredient> { new Ingredient { Name = "IngredientTest" } },
                PrepareMethod = "TestMethod"
            };
            testRecipe.Id = _services
                .BuildServiceProvider()
                .GetService<IRecipeService>()
                .CreateNewRecipe(new CreateNewRecipeInput {Name = testRecipe.Name, Calories = testRecipe.Calories, Portion = testRecipe.Portion }).Response.Id;

            _services
                .BuildServiceProvider()
                .GetService<IRecipeService>()
                .InsertIngredientsToRecipe(testRecipe.Id, new InsertIngredientsInput { Ingredients = testRecipe.Ingredients.Select(x => x.Name).ToList() });

            _services
                .BuildServiceProvider()
                .GetService<IRecipeService>()
                .InsertPrepareMethodToRecipe(testRecipe.Id, new InsertPrepareMethodInput { Description = testRecipe.PrepareMethod});

            var recipes = _services
                .BuildServiceProvider()
                .GetService<IRecipeService>()
                .GetAllRecipes();
            var getRecipeResult = _services
                 .BuildServiceProvider()
                 .GetService<IRecipeService>()
                 .GetRecipeById(1);
            var responseRecipe = getRecipeResult.Response;
            Assert
                .AreEqual(true, 
                recipes.Response.Count == 1 && 
                responseRecipe.Id == testRecipe.Id &&
                responseRecipe.Name == testRecipe.Name &&
                responseRecipe.Portion == testRecipe.Portion &&
                responseRecipe.Ingredients.First().Name == testRecipe.Ingredients.First().Name &&
                responseRecipe.PrepareMethod == testRecipe.PrepareMethod
                );
        }
    }
}