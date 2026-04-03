using CadastroDespesa.Dominio.Despesas.Servicos.Strategys;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Factory
{
    public class DespesaFactory
    {

        private readonly IServiceProvider serviceProvider;

        public DespesaFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDespesaStrategy Obter(TipoDespesa tipo)
        {
            return tipo.Id switch
            {
                1 => serviceProvider.GetRequiredService<DespesaFixaStrategy>(),
                2 => serviceProvider.GetRequiredService<DespesaParceladaStrategy>(),
                4 => serviceProvider.GetRequiredService<DespesaUnicaStrategy>(),
                _ => throw new NotSupportedException("Tipo de despesa não suportado")
            };
        }

    }
}
