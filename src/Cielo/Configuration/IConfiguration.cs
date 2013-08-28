using Cielo.Enums;

namespace Cielo.Configuration
{
    public interface IConfiguration
    {
        string CustomerKey { get; }
        string CustomerId { get; }
        string ReturnUrl { get; }
        Language Language { get; }
        string CurrencyId { get; }
    }
}