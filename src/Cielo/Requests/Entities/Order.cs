using System;
using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Extensions;
using DynamicBuilder;

namespace Cielo.Requests.Entities
{
    public class Order : ICieloPartialRequest
    {
        public string Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        public Order(string id, decimal total, DateTime date, string description = "")
        {
            Id = id;
            Total = total;
            Date = date;
            Description = description;
        }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            xmlParent.dados_pedido(Xml.Fragment(c =>
            {
                c.numero(Id);
                c.valor(Total.ToCieloFormatValue());
                c.moeda(configuration.CurrencyId);
                c.data_hora(Date.ToCieloFormatDate());
                c.descricao(Description);
                c.idioma(configuration.Language.GetDescription());
                c.soft_descriptor("");
            }));
        }
    }
}