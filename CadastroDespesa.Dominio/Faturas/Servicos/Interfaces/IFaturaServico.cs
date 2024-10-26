﻿using CadastroDespesa.Dominio.Faturas.Entidades;

namespace CadastroDespesa.Dominio.Faturas.Servicos.Interfaces
{
    public interface IFaturaServico
    {
        Task<Fatura> ValidarFaturaAsync(int id);
    }
}