using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeApi.Infra.Data.Db;

namespace RecipeApi.CrossCutting.Db
{
    public static class ContextConfig
    {
        public static IServiceCollection ConfigContext(this IServiceCollection services)
        {
            services.AddDbContext<RecipeContext>(opt => opt.UseInMemoryDatabase(databaseName: "RecipeContext"));
            RecipeExamplesSet.SetExamples();
            return services;
        }
    }
}
