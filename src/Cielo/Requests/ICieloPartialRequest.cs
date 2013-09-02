using Cielo.Configuration;

namespace Cielo.Requests
{
    public interface ICieloPartialRequest
    {
        void ToXml(dynamic xmlParent, IConfiguration configuration);
    }
}