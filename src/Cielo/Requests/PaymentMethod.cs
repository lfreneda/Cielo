using Cielo.Enums;

namespace Cielo.Requests
{
    public class PaymentMethod
    {
        public CreditCard CreditCard { get; private set; }
        public PurchaseType PurchaseType { get; private set; }
        public int Installments { get; private set; }

        public PaymentMethod(CreditCard creditCard, PurchaseType purchaseType, int installments = 1)
        {
            CreditCard = creditCard;
            PurchaseType = purchaseType;
            Installments = installments;
        }
    }
}