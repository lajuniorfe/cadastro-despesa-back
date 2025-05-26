using CadastroDespesa.Application.TiposPagamento.Profiles;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Dominio.Worker.Consumer;
using CadastroDespesa.Dominio.Worker.Consumer.Interface;
using CadastroDespesa.Dominio.Worker.Producer;
using CadastroDespesa.Dominio.Worker.Producer.Interface;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CadastroDespesa.IOC;

public static class InjecaoDependencia
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionUrl = Environment.GetEnvironmentVariable("DATA_URL");

        if (string.IsNullOrEmpty(connectionUrl))
        {
            connectionUrl = configuration.GetConnectionString("DatabaseUrl");
        }

        services.AddDbContext<EntityContexto>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(connectionUrl), ServiceLifetime.Scoped);
      

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(TipoPagamentoProfile).Assembly);

        RegisterTypesFromAssembly(services, "CadastroDespesa.Infra", "Repositorio");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Application", "App");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Dominio", "Servico");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Dominio", "Processar");

        services.AddHostedService<QueueConsumerWorker>();
        services.AddSingleton<IRabbitProducer, RabbitProducer>();
        services.AddSingleton<IRabbitConsumer, RabbitConsumer>();

        services.AddScoped<ProcessamentoPagamentoFactory>();
        services.AddScoped<ProcessamentoTipoDespesaFactory>();
   

    }

    private static void RegisterTypesFromAssembly(IServiceCollection services, string assemblyName, string suffix)
    {
        var assembly = Assembly.Load(assemblyName);
        var types = assembly.GetTypes()
            .Where(type => type.Name.EndsWith(suffix) && !type.IsAbstract && !type.IsInterface);

        foreach (var type in types)
        {
            var interfaceType = type.GetInterfaces().First(i => i.Name.EndsWith(suffix));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
