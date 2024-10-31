﻿using CadastroDespesa.Dominio.Despesas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces
{
    public interface ITipoDepesaProcessar
    {
        Task Processar(Despesa despesa, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao);
    }
}
