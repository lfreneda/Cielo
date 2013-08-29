using System.Linq;
using System.Xml.Linq;

namespace Cielo.Responses
{

    public class CreateTransactionResponse : CieloResponse<CreateTransactionResponse>
    {
        public CreateTransactionResponse(string content)
            : base(content)
        {
            Map(c => c.Tid, "tid");
            Map(c => c.AuthenticationUrl, "url-autenticacao");
        }

        public string Tid { get; set; }
        public string AuthenticationUrl { get; set; }
    }
}
