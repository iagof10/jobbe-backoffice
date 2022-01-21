using API.Data.Context;
using API.Data.Repository;
using API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CrossCutting.DependenciesConfigure
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(ICategoriaRepository), typeof(CategoriaRepository));
            serviceCollection.AddScoped(typeof(ISubCategoriaRepository), typeof(SubCategoriaRepository));
            serviceCollection.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            serviceCollection.AddScoped(typeof(ITelefoneUsuarioRepository), typeof(TelefoneUsuarioRepository));
            serviceCollection.AddScoped(typeof(ITipoChamadoRepository), typeof(TipoChamadoRepository));
            serviceCollection.AddScoped(typeof(IChamadoRepository), typeof(ChamadoRepository));
            serviceCollection.AddScoped(typeof(IChamadoCriticidadeRepository), typeof(ChamadoCriticidadeRepository));
            serviceCollection.AddDbContext<MyContext>(x => x.UseSqlServer(connectionString));
        }
    }
}