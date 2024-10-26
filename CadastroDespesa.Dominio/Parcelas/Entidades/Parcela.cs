﻿using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Parcelas.Entidades
{
    public class Parcela : BaseEntidade
    {
        public virtual Despesa Despesa { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual int NumeroParcela { get; protected set; }
        public virtual DateTime Data { get; protected set; }
        public virtual Fatura Fatura {get; protected set; }

        public virtual void SetDespesa(Despesa despesa)
        {
            Despesa = despesa;
        }

        public virtual void SetValor(decimal valor)
        {
            Valor = valor;
        }

        public virtual void SetNumeroParcela(int numeroParcela)
        {
            NumeroParcela = numeroParcela;
        }

        public virtual void SetData(DateTime data)
        {
            Data = data;
        }

        public virtual void SetFatura(Fatura fatura)
        {
            Fatura = fatura;
        }

        public IList<Parcela> CalcularDataParcela(int totalParcelas, DateTime dataDespesa, Despesa despesa)
        {
            IList<Parcela> parcelas = new List<Parcela>();
            for (var i = 0; i < totalParcelas; i++)
            {
                Parcela parcela = new()
                {
                    Id = 0,
                    Despesa = despesa,
                    Valor = despesa.Valor / totalParcelas,
                    NumeroParcela = i,
                    Data = i == 0 ? dataDespesa : dataDespesa.AddMonths(1)
                };

                parcelas.Add(parcela);
            }

            return parcelas;
        }
    }
}