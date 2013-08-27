using System.ComponentModel;

namespace Cielo.Enums
{
    public enum Bandeira
    {
        [Description("visa")]
        Visa,
        [Description("mastercard")]
        MasterCard,
        [Description("diners")]
        Diners,
        [Description("discover")]
        Discover,
        [Description("elo")]
        Elo,
        [Description("amex")]
        Amex,
        [Description("jcb")]
        Jcb,
        [Description("aura")]
        Aura
    }
}