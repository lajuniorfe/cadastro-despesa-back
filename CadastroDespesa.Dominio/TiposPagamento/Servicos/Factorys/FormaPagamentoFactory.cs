using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys
{
    public class FormaPagamentoFactory : IFormaPagamentoFactory
    {
        private readonly IServiceProvider serviceProvider;

        public FormaPagamentoFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IFormaPagamentoStrategy Obter(int idTipoPagamento)
        {
            return idTipoPagamento switch
            {
                1 => serviceProvider.GetRequiredService<CartaoPagamentoStrategy>(),
                2 => serviceProvider.GetRequiredService<SaldoPagamentoStrategy>(),
                3 => serviceProvider.GetRequiredService<SaldoPagamentoStrategy>(),

                _ => throw new NotSupportedException("Forma de pagamento não suportada")
            };
        }
    }
}
