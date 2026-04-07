using CadastroDespesa.Dominio.TipoDespesas.Servicos.Strategys;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos.Factorys
{
    public class TipoDespesaFactory : ITipoDespesaFactory
    {
        private readonly IServiceProvider serviceProvider;

        public TipoDespesaFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ITipoDespesaStrategy Obter(int tipo)
        {
            return tipo switch
            {
                1 => serviceProvider.GetRequiredService<TipoDespesaFixaStrategy>(),
                2 => serviceProvider.GetRequiredService<TipoDespesaParceladaStrategy>(),
                4 => serviceProvider.GetRequiredService<TipoDespesaUnicaStrategy>(),
                _ => throw new NotSupportedException("Tipo de despesa não suportado")
            };
        }

       
    }
}
