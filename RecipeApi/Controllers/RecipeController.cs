using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Service;
using RecipeApi.Service.Model;
using RecipeApi.Service.Models;
using RecipeApi.Service.Models.Input;

namespace RecipeApi.Controllers
{
    [Route("")]
    [ApiController]
    public class RecipeController : ControllerBase
    {


        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        [Route("v1/receitas")]
        public ActionResult<Result<CreateNewRecipeResult>> CreateNewRecipe([FromBody] CreateNewRecipeInput input)
        {
            if (input.Name == null)
            {
                return BadRequest(Result<CreateNewRecipeResult>.CreateErrorResult(new List<string> { "Name can't be null" }));
            }

            var result = _recipeService.CreateNewRecipe(input);

            if (result.IsSuccess)
                return Created("/receita", result);
            else
                return StatusCode(500, result);
        }

        [HttpPost]
        [Route("v1/receitas/{id}/ingredientes")]
        public ActionResult<Result<InsertIngredientsInput>> InsertIngredients([FromRoute] int id, [FromBody] InsertIngredientsInput input)
        {
            if (input.Ingredients == null || !input.Ingredients.Any())
            {
                return BadRequest(Result<InsertIngredientsInput>.CreateErrorResult(new List<string> { "Ingredients can't be empty" }));
            }

            var result = _recipeService.InsertIngredientsToRecipe(id, input);

            if (result.IsSuccess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpPost]
        [Route("v1/receitas/{id}/modo-preparo")]
        public ActionResult<Result<InsertPrepareMethodInput>> InsertPrepareMathod([FromRoute] int id, [FromBody] InsertPrepareMethodInput input)
        {
            if (input.Description == null)
            {
                return BadRequest(Result<InsertPrepareMethodInput>.CreateErrorResult(new List<string> { "Description can't be null" }));
            }

            var result = _recipeService.InsertPrepareMethodToRecipe(id, input);

            if (result.IsSuccess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpGet]
        [Route("v1/receitas")]
        public ActionResult<Result<InsertPrepareMethodInput>> GetAllRecipes()
        {

            var result = _recipeService.GetAllRecipes();

            if (result.IsSuccess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpGet]
        [Route("v1/receitas/{id}")]
        public ActionResult<Result<InsertPrepareMethodInput>> GetReicpe([FromRoute] int id)
        {

            var result = _recipeService.GetRecipeById(id);

            if (result.IsSuccess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }


    }
}
