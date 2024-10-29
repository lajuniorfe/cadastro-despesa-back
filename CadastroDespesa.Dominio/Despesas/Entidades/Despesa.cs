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
    public virtual bool StatusPagamento { get; protected set; }
    public virtual Categoria Categoria {get; protected set;}
    public virtual TipoDespesa TipoDespesa {get; protected set;}
    public virtual TipoPagamento TipoPagamento { get; protected set; }

    public Despesa() { }
    public Despesa(string? descricao, decimal valor, Categoria categoria, TipoDespesa tipoDespesa, TipoPagamento tipoPagamento)
    {
        SetDescricao(descricao);
        SetData();
        SetValor(valor);
        SetStatusPagamento(false);
        SetCategoria(categoria);
        SetTipoDespesa(tipoDespesa);
        SetTipoPagamento(tipoPagamento);
    }

    public virtual void SetCategoria(Categoria categoria)
    {
        Categoria = categoria;
    }

    public virtual void SetTipoDespesa(TipoDespesa tipoDespesa)
    {
        TipoDespesa = tipoDespesa;
    }

    public virtual void SetTipoPagamento(TipoPagamento tipoPagamento)
    {
        TipoPagamento = tipoPagamento;
    }
    public virtual void SetStatusPagamento(bool status){
        StatusPagamento = status;
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
