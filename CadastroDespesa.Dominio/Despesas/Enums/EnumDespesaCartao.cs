using System.ComponentModel;
using System.Reflection;

namespace CadastroDespesa.Dominio.Despesas.Enums
{
    public enum EnumDespesaCartao
    {
        [Description("Nubank-Junior")]
        Nubank = 0,

        [Description("Caixa")]
        Caixa = 1,

        [Description("Nubank-Allana")]
        NubankAllana = 2,

        [Description("Mercado Pago")]
        MercadoPago = 3,

        [Description("Renner")]
        Renner = 4,

        [Description("C&A")]
        CeA = 5,

    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field?.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attr)
            {
                return attr.Description;
            }

            return value.ToString();
        }
    }

}

