using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.DTO.Investimentos.Responses
{
    public class InvestimentoResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}
