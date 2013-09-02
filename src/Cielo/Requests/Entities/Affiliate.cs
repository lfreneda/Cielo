using Cielo.Configuration;
using DynamicBuilder;

namespace Cielo.Requests.Entities
{
    public class Affiliate : ICieloPartialRequest
    {
        public void ToXml(dynamic xmlParent, IConfiguration configuration)
        {
            xmlParent.dados_ec(Xml.Fragment(c =>
            {
                c.numero(configuration.CustomerId);
                c.chave(configuration.CustomerKey);
            }));
        }
    }
}