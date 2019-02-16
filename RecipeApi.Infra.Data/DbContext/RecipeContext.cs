
using Microsoft.EntityFrameworkCore;
using RecipeApi.Infra.Data.DTO;

namespace RecipeApi.Infra.Data.Db
{
    public class RecipeContext : DbContext
    {

        public DbSet<RecipeDTO> Recipes { get; set; }
        public DbSet<IngredientDTO> Ingredients { get; set; }
        public DbSet<PrepareMethodDTO> PrepareMethods { get; set; }

        public RecipeContext(DbContextOptions<RecipeContext> options)
              : base(options)
        {
        }
    }
}
