using Cielo.Configuration;
using Cielo.Enums;
using DynamicBuilder;

namespace Cielo.Requests.Entities
{
    public class CreditCardData : ICieloPartialRequest
    {
        public string CreditCardNumber { get; private set; }
        private readonly CreditCardExpiration _expiration;
        public string Expiration { get { return _expiration.ToString(); } }
        public SecurityCodeIndicator Indicator { get; private set; }
        public int SecurityCode { get; private set; }

        public CreditCardData(string creditCardNumber,
                              CreditCardExpiration expiration,
                              SecurityCodeIndicator indicator,
                              int securityCode)
        {
            _expiration = expiration;
            CreditCardNumber = creditCardNumber;
            Indicator = indicator;
            SecurityCode = securityCode;
        }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            xmlParent.dados_portador(Xml.Fragment(c =>
            {
                c.numero(CreditCardNumber);
                c.validade(Expiration);
                c.indicador((int)Indicator);
                c.codigo_seguranca(SecurityCode);
                c.token(string.Empty); //not supported yet :P
            }));
        }
    }
}