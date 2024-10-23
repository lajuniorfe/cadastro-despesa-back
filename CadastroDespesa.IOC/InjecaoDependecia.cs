using CadastroDespesa.Application.Despesas;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Base.Repositorios;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.Despesas.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDespesa.IOC;

public static class InjecaoDependecia
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionUrl = Environment.GetEnvironmentVariable("DATA_URL");

        if (string.IsNullOrEmpty(connectionUrl))
        {
            Console.WriteLine("entrei aqui");
            connectionUrl = configuration.GetConnectionString("DatabaseUrl");
        }

        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql(connectionUrl), ServiceLifetime.Scoped);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IDespesasRepositorio, DespesaRepositorio>();
        services.AddScoped<IDespesaApp, DespesaApp>();
        services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));

    }
}
