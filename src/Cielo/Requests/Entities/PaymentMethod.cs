using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Enums;
using DynamicBuilder;

namespace Cielo.Requests.Entities
{
    public class PaymentMethod : ICieloPartialRequest
    {
        public CreditCard CreditCard { get; private set; }
        public PurchaseType PurchaseType { get; private set; }
        public CreditCardData CreditCardData { get; private set; }
        public int Installments { get; private set; }

        public PaymentMethod(CreditCard creditCard,
                             PurchaseType purchaseType,
                             CreditCardData creditCardData = null,
                             int installments = 1)
        {
            CreditCard = creditCard;
            PurchaseType = purchaseType;
            CreditCardData = creditCardData;
            Installments = installments;
        }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            xmlParent.forma_pagamento(Xml.Fragment(c =>
            {
                c.bandeira(CreditCard.GetDescription());
                c.produto(PurchaseType.GetDescription());
                c.parcelas(Installments);
            }));
        }
    }
}