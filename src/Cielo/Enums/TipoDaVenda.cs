using System.ComponentModel;

namespace Cielo.Enums
{
    public enum TipoVenda
    {
        [Description("1")]
        CreditoAVista,
        [Description("2")]
        ParceladoLoja,
        [Description("3")]
        ParceladoAdministradora,
        [Description("A")]
        Debito
    }
}