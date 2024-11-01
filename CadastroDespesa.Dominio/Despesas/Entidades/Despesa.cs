using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa : BaseEntidade
{
    public virtual string? Descricao {get; protected set;}
    public virtual DateTime Data {get; protected set;}
    public virtual decimal Valor {get; protected set;}
    public virtual Categoria Categoria {get; protected set;}
    public virtual TipoDespesa TipoDespesa {get; protected set;}

    public Despesa() { }
    public Despesa(string? descricao, decimal valor, Categoria categoria, TipoDespesa tipoDespesa)
    {
        SetDescricao(descricao);
        SetData();
        SetValor(valor);
        SetCategoria(categoria);
        SetTipoDespesa(tipoDespesa);
    }

    public virtual void SetCategoria(Categoria categoria)
    {
        Categoria = categoria;
    }

    public virtual void SetTipoDespesa(TipoDespesa tipoDespesa)
    {
        TipoDespesa = tipoDespesa;
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
