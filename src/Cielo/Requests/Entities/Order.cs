using System;
using System.ComponentModel;
using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Extensions;
using DynamicBuilder;
using RestSharp.Extensions;

namespace Cielo.Requests.Entities
{
    public class Order : ICieloPartialRequest
    {
        public string Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string SoftDescriptor { get; set; }

        public Order(string id, decimal total, DateTime date, string description = "", string softDescriptor = "")
        {
            Id = id;
            Total = total;
            Date = date;
            Description = description;
            SoftDescriptor = softDescriptor;
        }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            var lang =
                configuration.Language.GetType()
                    .GetField(configuration.Language.ToString())
                    .GetAttribute<DescriptionAttribute>();
            xmlParent.dados_pedido(Xml.Fragment(c =>
            {
                c.numero(Id);
                c.valor(Total.ToCieloFormatValue());
                c.moeda(configuration.CurrencyId);
                c.data_hora(Date.ToCieloFormatDate());
                c.descricao(Description);
                c.idioma(lang.Description);
                c.soft_descriptor(SoftDescriptor);
            }));
        }
    }
}