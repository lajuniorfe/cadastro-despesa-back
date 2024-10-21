using System.Configuration;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Despesas.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CadastroDespesa.IOC;

public static class InjecaoDependecia
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration){
        
        var connectionUrl = configuration.GetConnectionString("DatabaseUrl");
      
        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql(connectionUrl));

        services.AddScoped<DespesaRepositorio, DespesaRepositorio>();
    }

     public static void AddInfrastructureServicesProducao(this IServiceCollection services, IConfiguration configuration){
        var connectionUrl = Environment.GetEnvironmentVariable("DATA_URL"); 

        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql(connectionUrl));

        services.AddScoped<DespesaRepositorio, DespesaRepositorio>();
     }
}
