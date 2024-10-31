using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaConvenienciaProcessar : ITipoDespesaConvenienciaProcessar
    {
        public async Task Processar(int idTipoDespesa, int idTipoPagamento, int idDespesa)
        {
            await ProcessarTipoDespesaConveniencia();
        }

        public Task ProcessarTipoDespesaConveniencia()
        {
            //Despesa Conveniencia é fluxo comum com uma transaçao. Se tiver parcela(criar)

            throw new NotImplementedException();
        }
    }
}
