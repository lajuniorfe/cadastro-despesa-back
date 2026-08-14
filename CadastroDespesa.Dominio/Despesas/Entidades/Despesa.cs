using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.Usuarios.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa : BaseEntidade
{
    public virtual string? Descricao { get; protected set; }
    public virtual DateTime Data { get; protected set; }
    public virtual decimal Valor { get; protected set; }
    public virtual int? TotalParcela { get; protected set; }

    #region relacionamento
    public virtual int IdCategoria { get; protected set; }
    public virtual Categoria? Categoria { get; protected set; }
    public virtual int IdRecorrencia { get; protected set; }
    public virtual Recorrencia? Recorrencia { get; protected set; }
    public virtual int IdUsuario { get; protected set; }
    public virtual Usuario Usuario { get; protected set; }

    public virtual int IdTipoPagamento { get; protected set; }
    public virtual TipoPagamento TipoPagamento { get;  set; }

    #endregion


    protected Despesa() { }
    public Despesa(string? descricao, decimal valor, DateTime data, int categoria, int recorrencia, int totalParcela, int idUsuario, int idTipoPagamento)
    {
        SetDescricao(descricao);
        SetData(data);
        SetValor(valor);
        SetCategoria(categoria);
        SetRecorrencia(recorrencia);
        SetTotalParcela(totalParcela);
        SetUsuario(idUsuario);
        SetTipoPagamento(idTipoPagamento);
    }

    public void SetCategoria(int categoria)
    {
        IdCategoria = categoria;
    }

    public void SetRecorrencia(int recorrencia)
    {
        IdRecorrencia = recorrencia;
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

    public void SetTotalParcela(int totalParcela)
    {
        TotalParcela = totalParcela;
    }

    public void SetUsuario(int idUsuario)
    {
        IdUsuario = idUsuario;
    }

    public void SetTipoPagamento(int tipoPagamento)
    {
        IdTipoPagamento = tipoPagamento;
    }
}