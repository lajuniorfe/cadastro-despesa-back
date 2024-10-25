using CadastroDespesa.Application.Cartoes;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Application.Categorias;
using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.Application.Despesas;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Application.TipoDespesas;
using CadastroDespesa.Application.TipoDespesas.Interfaces;
using CadastroDespesa.Dominio.Base.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Dominio.Categorias.Servicos;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Infra.Cartoes.Repositorios;
using CadastroDespesa.Infra.Categorias.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.Despesas.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CadastroDespesa.IOC;

public static class InjecaoDependecia
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionUrl = Environment.GetEnvironmentVariable("DATA_URL");

        if (string.IsNullOrEmpty(connectionUrl))
        {
            connectionUrl = configuration.GetConnectionString("DatabaseUrl");
        }

        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql(connectionUrl), ServiceLifetime.Scoped);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var infraAssembly = Assembly.Load("CadastroDespesa.Infra");
        var repositorios = infraAssembly.GetTypes()
        .Where(type => type.Name.EndsWith("Repositorio") && !type.IsAbstract && !type.IsInterface);

        foreach (var repositorio in repositorios)
        {
            var interfaceType = repositorio.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Repositorio"));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, repositorio);
            }
        }


        var applicationAssembly = Assembly.Load("CadastroDespesa.Application");
        var aplicacoes = applicationAssembly.GetTypes()
        .Where(type => type.Name.EndsWith("App") && !type.IsAbstract && !type.IsInterface);

        foreach (var aplicacao in aplicacoes)
        {
            var interfaceType = aplicacao.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("App"));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, aplicacao);
            }
        }

        var ServicosAssembly = Assembly.Load("CadastroDespesa.Dominio");
        var servicos = ServicosAssembly.GetTypes()
        .Where(type => type.Name.EndsWith("Servico") && !type.IsAbstract && !type.IsInterface);

        foreach (var servico in servicos)
        {
            var interfaceType = servico.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Servico"));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, servico);
            }
        }

        //services.AddScoped<IDespesaServico, DespesaServico>();
        //services.AddScoped<ICartaoServico, CartaoServico>();
        //services.AddScoped<ICategoriaServico, CategoriaServico>();
        //services.AddScoped<ITipoDespesaServico, TipoDespesaServico>();
    }
}
