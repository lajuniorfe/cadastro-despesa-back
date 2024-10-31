using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaRecorrenteProcessar : ITipoDespesaRecorrenteProcessar
    {
        public async Task Processar(int idTipoDespesa, int idTipoPagamento, Despesa despesa)
        {
            await ProcessarTipoDespesaRecorrente();
        }

        public Task ProcessarTipoDespesaRecorrente()
        {

            //Despesa Recorrente, Será cadastrada normalmente e será criada uma transaçao
            //para todos os meses do ano com valor.

            throw new NotImplementedException();
        }
    }
}
