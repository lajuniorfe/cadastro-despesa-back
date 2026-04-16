using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.Usuarios.Entidades;

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
    public virtual Categoria? Categoria { get; protected set; }
    public virtual int IdRecorrencia { get; protected set; }
    public virtual Recorrencia? Recorrencia { get; protected set; }
    //public virtual int? IdFatura { get; protected set; }
    //public virtual Fatura? Fatura { get; protected set; }
    public virtual int IdUsuario { get; protected set; }
    public virtual Usuario Usuario { get; protected set; }

    #endregion


    protected Despesa() { }
    public Despesa(string? descricao, decimal valor, DateTime data, int categoria, int recorrencia, int totalParcela, int idUsuario)
    {
        SetDescricao(descricao);
        SetData(data);
        SetValor(valor);
        SetCategoria(categoria);
        SetRecorrencia(recorrencia);
        SetTotalParcela(totalParcela);
        SetUsuario(idUsuario);
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

    public void SetNumeroParcela(int numeroParcela)
    {
        NumeroParcela = numeroParcela;
    }

    public void SetValorParcela(decimal valorParcela)
    {
        ValorParcela = valorParcela;
    }

    //public void SetFatura(int idFatura)
    //{
    //    IdFatura = idFatura;
    //}

    public void SetUsuario(int idUsuario)
    {
        IdUsuario = idUsuario;
    }

  
    


   
}