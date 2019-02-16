using Microsoft.EntityFrameworkCore;
using RecipeApi.CrossCutting.Db;
using RecipeApi.Domain.Repository;
using RecipeApi.Infra.Data;
using RecipeApi.Infra.Data.Db;
using RecipeApi.Service;
using SimpleInjector;
using System;
namespace RecipeApi.Infra.CrossCutting.IoC
{
    public static class IocConfig
    {
        public static Container RegisterIoc(this Container container)
        {
            ////Mapper
            //container.Register(() => new MapperConfiguration(MapperConfig.Configure).CreateMapper(), Lifestyle.Singleton);

            //Serviços
            container.Register<IRecipeService, RecipeService>(Lifestyle.Transient);

            //Repository
            container.Register<IRecipeRepository, RecipeRepository>(Lifestyle.Transient);




            return container;
        }
    }
}
