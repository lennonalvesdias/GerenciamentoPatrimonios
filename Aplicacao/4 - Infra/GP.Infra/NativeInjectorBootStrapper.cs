using GP.Aplicacao.Interfaces.ServicosApp;
using GP.Aplicacao.ServicosApp;
using GP.Dados.Contexto;
using GP.Dados.Repositorios;
using GP.Dominio.Interfaces.Repositorios;
using GP.Dominio.Interfaces.Servicos;
using GP.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace GP.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Aplicacao
            services.AddScoped<IPatrimonioServicoApp, PatrimonioServicoApp>();
            services.AddScoped<IMarcaServicoApp, MarcaServicoApp>();

            // Dominio
            services.AddScoped<IPatrimonioServico, PatrimonioServico>();
            services.AddScoped<IMarcaServico, MarcaServico>();

            // Infra
            services.AddScoped<GPContexto>();

            services.AddScoped<IPatrimonioRepositorio, PatrimonioRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
        }
    }
}
