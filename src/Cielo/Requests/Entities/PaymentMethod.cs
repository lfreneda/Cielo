using System.ComponentModel;
using Cielo.Configuration;
using Cielo.Enums;
using DynamicBuilder;
using RestSharp.Extensions;

namespace Cielo.Requests.Entities
{
    public class PaymentMethod : ICieloPartialRequest
    {
        public PaymentMethod(CreditCard creditCard,
            PurchaseType purchaseType,
            int installments = 1)
        {
            CreditCard = creditCard;
            PurchaseType = purchaseType;
            Installments = installments;
        }

        public CreditCard CreditCard { get; private set; }
        public PurchaseType PurchaseType { get; private set; }
        public int Installments { get; private set; }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            var creditCard =
                CreditCard.GetType().GetField(CreditCard.ToString()).GetAttribute<DescriptionAttribute>();
            var purchaseType =
                PurchaseType.GetType().GetField(PurchaseType.ToString()).GetAttribute<DescriptionAttribute>();
            xmlParent.forma_pagamento(Xml.Fragment(c =>
            {
                c.bandeira(creditCard.Description);
                c.produto(purchaseType.Description);
                c.parcelas(Installments);
            }));
        }
    }
}