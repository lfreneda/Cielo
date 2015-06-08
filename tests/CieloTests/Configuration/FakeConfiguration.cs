using Cielo.Configuration;
using Cielo.Enums;

namespace CieloTests.Configuration
{
    public class FakeConfiguration : IConfiguration
    {
        public string CustomerKey
        {
            get { return "e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832"; }
        }

        public string CustomerId
        {
            get { return "1001734898"; }
        }

        public string ReturnUrl
        {
            get { return "http://localhost:7001/lojaexemplo-2.1/retorno.jsp"; }
        }

        public Language Language
        {
            get { return Language.Portuguese; }
        }

        public string CurrencyId
        {
            get { return "986"; }
        }
    }
}