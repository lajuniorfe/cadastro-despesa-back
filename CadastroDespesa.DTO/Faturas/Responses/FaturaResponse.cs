using CadastroDespesa.DTO.Cartao.Responses;

namespace CadastroDespesa.DTO.Faturas.Responses
{
    public class FaturaResponse
    {
        public int Id { get; set; }
        public CartaoResponse Cartao { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
