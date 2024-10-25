using CadastroDespesa.Dominio.Base.Entidades;
using System;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa : BaseEntidade
{
    public virtual string? Descricao {get; protected set;}
    public virtual DateTime Data {get; protected set;}
    public virtual decimal Valor {get; protected set;}

    public Despesa(string? descricao, decimal valor)
    {
        SetDescricao(descricao);
        SetData();
        SetValor(valor);
    }

    public virtual void SetDescricao(string? descricao)
    {
        Descricao = descricao;
    }

    public virtual void SetValor(decimal valor)
    {
        Valor = valor;
    }

    public virtual void SetData()
    {
        Data = Data = DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Unspecified);
    }
}
