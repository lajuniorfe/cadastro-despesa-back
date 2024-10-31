using CadastroDespesa.Application.TiposPagamento.Profiles;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Application.Despesas;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Infra.Despesas.Repositorios;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Servicos;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Infra.Cartoes.Repositorios;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Infra.TipoDespesas.Repositorios;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Application.Cartoes;
using CadastroDespesa.Application.TipoDespesas.Interfaces;
using CadastroDespesa.Application.TipoDespesas;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Faturas.Servicos;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Servicos;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Infra.Faturas.Repositorios;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Infra.Categorias.Repositorios;
using CadastroDespesa.Dominio.Parcelas.Repositorios;
using CadastroDespesa.Infra.Parcelas.Repositorios;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using CadastroDespesa.Infra.TiposPagamento.Repositorios;
using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.Application.Categorias;
using CadastroDespesa.Application.TiposPagamento.Interfaces;
using CadastroDespesa.Application.TiposPagamento;

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
