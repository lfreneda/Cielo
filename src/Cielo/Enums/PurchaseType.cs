using System.ComponentModel;

namespace Cielo.Enums
{
    public enum PurchaseType
    {
        [Description("1")]
        Credit,
        [Description("2")]
        StoreInstallmentPayment,
        [Description("3")]
        CreditCardCompanyInstallmentPayment,
        [Description("A")]
        Debit
    }
}