using CadastroDespesa.Application.TiposPagamento.Profiles;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.UnitOfWork;
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
                options.UseLazyLoadingProxies().UseNpgsql(connectionUrl), ServiceLifetime.Scoped);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(TipoPagamentoProfile).Assembly);

        //services.AddScoped<ICartaoServico, CartaoServico>();
        //services.AddScoped<IDespesaServico, DespesaServico>();
        //services.AddScoped<ITipoDespesaServico, TipoDespesaServico>();
        //services.AddScoped<IFaturaServico, FaturaServico>();
        //services.AddScoped<ICategoriaServico, CategoriaServico>();
        //services.AddScoped<IParcelaServico, ParcelaServico>();
        //services.AddScoped<ITipoPagamentoServico, TipoPagamentoServico>();

        //services.AddScoped<IDespesaRepositorio, DespesaRepositorio>();
        //services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();
        //services.AddScoped<ITipoDespesaRepositorio, TipoDespesaRepositorio>();
        //services.AddScoped<IFaturaRepositorio, FaturaRepositorio>();
        //services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        //services.AddScoped<IParcelaRepositorio, ParcelaRepositorio>();
        //services.AddScoped<ITipoPagamentoRepositorio, TipoPagamentoRepositorio>();

        //services.AddScoped<IDespesaApp, DespesaApp>();
        //services.AddScoped<ICartaoApp, CartaoApp>();
        //services.AddScoped<ITipoDespesasApp, TipoDespesaApp>();
        //services.AddScoped<ICategoriaApp, CategoriaApp>();
        //services.AddScoped<ITipoPagamentoApp, TipoPagamentoApp>();

        RegisterTypesFromAssembly(services, "CadastroDespesa.Infra", "Repositorio");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Application", "App");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Dominio", "Servico");
        RegisterTypesFromAssembly(services, "CadastroDespesa.Dominio", "Processar");


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
            var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith(suffix));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
