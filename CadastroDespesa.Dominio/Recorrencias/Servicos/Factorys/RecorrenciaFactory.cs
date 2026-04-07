using CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Factorys
{
    public class RecorrenciaFactory : IRecorrenciaFactory
    {
        private readonly IServiceProvider serviceProvider;

        public RecorrenciaFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IRecorrenciaStrategy Obter(int tipo)
        {
            return tipo switch
            {
                1 => serviceProvider.GetRequiredService<RecorrenciaFixaStrategy>(),
                2 => serviceProvider.GetRequiredService<RecorrenciaParceladaStrategy>(),
                4 => serviceProvider.GetRequiredService<RecorrenciaUnicaStrategy>(),
                _ => throw new NotSupportedException("Tipo de despesa não suportado")
            };
        }

       
    }
}
