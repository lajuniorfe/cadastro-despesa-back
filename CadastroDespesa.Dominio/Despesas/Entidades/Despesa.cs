using System;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa
{
    public virtual int Id {get; protected set;}
    public virtual string? Descricao {get; protected set;}
    public virtual DateTime Data {get; protected set;}
    public virtual decimal valor {get; protected set;}
}
