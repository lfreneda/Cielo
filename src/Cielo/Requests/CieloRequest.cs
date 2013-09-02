using Cielo.Configuration;
using Cielo.Requests.Entities;

namespace Cielo.Requests
{
    public abstract class CieloRequest : ICieloRequest
    {
        protected readonly IConfiguration Configuration;
        protected Affiliate Affiliate = new Affiliate();

        protected CieloRequest(IConfiguration configuration)
        {
            if (configuration == null) configuration = new DefaultCieloConfiguration();

            Configuration = configuration;
        }

        public abstract string ToXml(bool indent);
    }
}