using Cielo.Configuration;
using Cielo.Enums;

namespace CieloTests.Configuration
{
    public class CustomConfiguration : IConfiguration
    {
        public string CustomerKey { get; set; }
        public string CustomerId { get; set; }
        public string ReturnUrl { get; set; }
        public Language Language { get; set; }
        public string CurrencyId { get; set; }
    }
}