using System.ComponentModel;

namespace CadastroDespesa.Dominio.Investimentos.Enums
{
    public enum TipoInvestimentoEnum
    {

        [Description("Reserva-Emergencia")]
        ReservaEmergencia = 0,

        [Description("Bolsa-Valores")]
        BolsaValores = 1,

        [Description("Retirada")]
        Retirada = 2,
    }
}
