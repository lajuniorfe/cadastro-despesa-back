﻿using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaConvenienciaProcessar : ITipoDepesaProcessar
    {
       Task ProcessarTipoDespesaConveniencia(Despesa despesa, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao);
    }
}
