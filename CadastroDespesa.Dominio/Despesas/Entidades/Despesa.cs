using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Entidades;

public class Despesa : BaseEntidade
{
    public virtual string? Descricao { get; protected set; }
    public virtual DateTime Data { get; protected set; }
    public virtual decimal Valor { get; protected set; }
    public virtual int? NumeroParcela { get; protected set; }
    public virtual int? TotalParcela { get; protected set; }
    public virtual decimal ValorParcela { get; protected set; }

    #region relacionamento
    public virtual int IdCategoria { get; protected set; }
    public virtual int IdTipoDespesa { get; protected set; }
    public virtual Categoria? Categoria { get; protected set; }
    public virtual TipoDespesa? TipoDespesa { get; protected set; }
    public virtual int? IdFatura { get; protected set; }
    public virtual Fatura? Fatura { get; protected set; }

    #endregion


    protected Despesa() { }
    public Despesa(string? descricao, decimal valor, DateTime data, int categoria, int tipoDespesa, int totalParcela)
    {
        SetDescricao(descricao);
        SetData(data);
        SetValor(valor);
        SetCategoria(categoria);
        SetTipoDespesa(tipoDespesa);
        SetTotalParcela(totalParcela);
    }

    public void SetCategoria(int categoria)
    {
        IdCategoria = categoria;
    }

    public void SetTipoDespesa(int tipoDespesa)
    {
        IdTipoDespesa = tipoDespesa;
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

    public void SetNumeroParcela(int numeroParcela)
    {
        NumeroParcela = numeroParcela;
    }

    public void SetValorParcela(decimal valorParcela)
    {
        ValorParcela = valorParcela;
    }

    public void SetFatura(int idFatura)
    {
        IdFatura = idFatura;
    }

    public static IEnumerable<Despesa> CriarParcelada(string descricao,
            decimal valorTotal,
            DateTime dataInicial,
            int idCategoria,
            int idTipoDespesa,
            int totalParcelas)
    {
        var despesas = new List<Despesa>();

        for (int i = 0; i < totalParcelas; i++)
        {
            var valorParcela = valorTotal / totalParcelas;
            var dataParcela = dataInicial.AddMonths(i);

            var despesa = new Despesa(
                 descricao,
                 valorTotal,
                 dataParcela,
                 idCategoria,
                 idTipoDespesa,
                 totalParcelas
             );

            despesa.SetNumeroParcela(i + 1);
            despesa.SetValorParcela(valorParcela);

            despesas.Add(despesa);
        }

        return despesas;
    }

    public static Despesa CriarSemParcela(string descricao,
          decimal valor,
          DateTime data,
          int idCategoria,
          int idTipoDespesa)
    {
        var despesa = new Despesa(
            descricao,
            valor,
            data,
            idCategoria,
            idTipoDespesa,
            1
        );

        despesa.SetNumeroParcela(1);

        return despesa;
    }
}