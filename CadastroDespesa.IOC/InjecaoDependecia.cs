using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Despesas.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDespesa.IOC;

public static class InjecaoDependecia
{
    public static void AddInfrastructureServices(this IServiceCollection services){
        
        services.AddDbContext<EntityContexto>(options =>
                options.UseNpgsql("sua_string_de_conexao"));

        services.AddScoped<DespesaRepositorio, DespesaRepositorio>();
    }
}
