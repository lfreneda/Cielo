using Cielo.Enums;

namespace Cielo.Requests.Entities
{
    public class CreditCardData
    {
        public string CreditCardNumber { get; set; }
        private readonly CreditCardExpiration _expiration;
        public string Expiration { get { return _expiration.ToString(); } }
        public SecurityCodeIndicator Indicator { get; set; }
        public string SecurityCode { get; set; }

        public CreditCardData(string creditCardNumber, 
                              CreditCardExpiration expiration, 
                              SecurityCodeIndicator indicator, 
                              string securityCode)
        {
            _expiration = expiration;
            CreditCardNumber = creditCardNumber;
            Indicator = indicator;
            SecurityCode = securityCode;
        }
    }
}