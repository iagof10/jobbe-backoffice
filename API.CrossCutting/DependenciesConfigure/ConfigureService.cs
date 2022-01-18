using API.Data.Repository;
using API.Domain.Repository;
using API.Domain.Service;
using API.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CrossCutting.DependenciesConfigure
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(ICategoriaService), typeof(CategoriaService));
            serviceCollection.AddTransient(typeof(ISubCategoriaService), typeof(SubCategoriaService));
        }
    }
}
