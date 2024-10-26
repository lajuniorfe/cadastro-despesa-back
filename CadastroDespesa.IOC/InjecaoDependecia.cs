using AutoMapper;
using CadastroDespesa.Infra.Contexto;
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


        var profileAssembly = Assembly.Load("CadastroDespesa.Application");
        var profiles = profileAssembly.GetTypes()
            .Where(type => typeof(Profile).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);

        foreach (var profile in profiles)
        {
            services.AddAutoMapper(profile); 
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


    }
}
