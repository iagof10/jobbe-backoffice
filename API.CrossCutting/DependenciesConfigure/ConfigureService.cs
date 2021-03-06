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
            serviceCollection.AddTransient(typeof(IUsuarioService), typeof(UsuarioService));
            serviceCollection.AddTransient(typeof(ITelefoneUsuarioService), typeof(TelefoneUsuarioService));
            serviceCollection.AddTransient(typeof(ITipoChamadoService), typeof(TipoChamadoService));
            serviceCollection.AddTransient(typeof(IChamadoService), typeof(ChamadoService));
            serviceCollection.AddTransient(typeof(IChamadoCriticidadeService), typeof(ChamadoCriticidadeService));
            serviceCollection.AddTransient(typeof(IChamadoStatusService), typeof(ChamadoStatusService));
            serviceCollection.AddTransient(typeof(IComentarioPerfilService), typeof(ComentarioPerfilService));
            serviceCollection.AddTransient(typeof(IContatoPrestadorService), typeof(ContatoPrestadorService));
            serviceCollection.AddTransient(typeof(IItemChamadoService), typeof(ItemChamadoService));
            serviceCollection.AddTransient(typeof(ISubCategoriaPrestadorService), typeof(SubCategoriaPrestadorService));
        }
    }
}
