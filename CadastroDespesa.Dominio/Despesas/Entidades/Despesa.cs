using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa : BaseEntidade
{
    public virtual string? Descricao { get; protected set; }
    public virtual DateTime Data { get; protected set; }
    public virtual decimal Valor { get; protected set; }
    public virtual Categoria? Categoria { get; protected set; }
    public virtual TipoDespesa? TipoDespesa { get; protected set; }

    public Despesa() { }
    public Despesa(string? descricao, decimal valor, DateTime data, Categoria categoria, TipoDespesa tipoDespesa)
    {
        SetDescricao(descricao);
        SetData(data);
        SetValor(valor);
        SetCategoria(categoria);
        SetTipoDespesa(tipoDespesa);
    }

    public void SetCategoria(Categoria categoria)
    {
        Categoria = categoria;
    }

    public void SetTipoDespesa(TipoDespesa tipoDespesa)
    {
        TipoDespesa = tipoDespesa;
    }

    public void SetDescricao(string? descricao)
    {
        Descricao = descricao;
    }

    public void SetValor(decimal valor)
    {
        Valor = valor;
    }

    public void SetData(DateTime data)
    {
        Data = Data = DateTime.SpecifyKind(data.Date, DateTimeKind.Unspecified);
    }
}
