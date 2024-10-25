using CadastroDespesa.Application.Cartoes;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Application.Categorias;
using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.Application.Despesas;
using CadastroDespesa.Application.Despesas.Interfaces;
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
using CadastroDespesa.Infra.Cartoes.Repositorios;
using CadastroDespesa.Infra.Categorias.Repositorios;
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
            connectionUrl = configuration.GetConnectionString("DatabaseUrl");
        }

        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql(connectionUrl), ServiceLifetime.Scoped);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
        services.AddScoped<IDespesasRepositorio, DespesaRepositorio>();
        services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();
        services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

        services.AddScoped<IDespesaApp, DespesaApp>();
        services.AddScoped<ICartaoApp, CartaoApp>();
        services.AddScoped<ICategoriaApp, CategoriaApp>();

        services.AddScoped<IDespesaServico, DespesaServico>();
        services.AddScoped<ICartaoServico, CartaoServico>();
        services.AddScoped<ICategoriaServico, CategoriaServico>();
    }
}
