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
    public class TipoDespesaEmergencialProcessar : ITipoDespesaEmergencialProcessar
    {
        public async Task Processar(int idTipoDespesa, int idTipoPagamento, Despesa despesa)
        {
            await ProcessarTipoDespesaEmergencial();
        }

        public Task ProcessarTipoDespesaEmergencial()
        {

            //Despesa emergencial é fluxo comum com uma transaçao. Se tiver parcela(criar)

            throw new NotImplementedException();
        }
    }
}
