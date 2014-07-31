using System.ComponentModel;
using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Enums;
using DynamicBuilder;
using RestSharp.Extensions;

namespace Cielo.Requests.Entities
{
    public class PaymentMethod : ICieloPartialRequest
    {
        public CreditCard CreditCard { get; private set; }
        public PurchaseType PurchaseType { get; private set; }
        public int Installments { get; private set; }

        public PaymentMethod(CreditCard creditCard,
                             PurchaseType purchaseType,
                             int installments = 1)
        {
            CreditCard = creditCard;
            PurchaseType = purchaseType;
            Installments = installments;
        }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            var creditCard =
                this.CreditCard.GetType().GetField(this.CreditCard.ToString()).GetAttribute<DescriptionAttribute>();
            var purchaseType =
                this.PurchaseType.GetType().GetField(this.PurchaseType.ToString()).GetAttribute<DescriptionAttribute>();
            xmlParent.forma_pagamento(Xml.Fragment(c =>
            {
                c.bandeira(creditCard.Description);
                c.produto(purchaseType.Description);
                c.parcelas(Installments);
            }));
        }
    }
}