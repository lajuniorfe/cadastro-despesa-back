using AutoMapper.Internal;
using CadastroDespesa.Application.Cartoes;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Application.Despesas;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Base.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Infra.Cartoes.Repositorios;
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

        services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
        services.AddScoped<IDespesasRepositorio, DespesaRepositorio>();
        services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();

        services.AddScoped<IDespesaApp, DespesaApp>();
        services.AddScoped<ICartaoApp, CartaoApp>();

        services.AddScoped<IDespesaServico, DespesaServico>();
        services.AddScoped<ICartaoServico, CartaoServico>();
       

    }
}
