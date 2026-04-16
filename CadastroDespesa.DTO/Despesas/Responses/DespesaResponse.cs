using CadastroDespesa.DTO.Categorias.Responses;
using CadastroDespesa.DTO.Faturas.Responses;
using CadastroDespesa.DTO.Recorrencias.Responses;
using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.DTO.Despesas.Responses;

public class DespesaResponse
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public bool StatusPagamento { get; set; }
    public CategoriaResponse? Categoria { get; set; }
    public RecorrenciaResponse? Recorrencia { get; set; }
    //public FaturaResponse? Fatura { get; set; }
    public UsuarioResponse Usuario { get; set; }
}
