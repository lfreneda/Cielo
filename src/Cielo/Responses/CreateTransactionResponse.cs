using System.Linq;
using System.Xml.Linq;

namespace Cielo.Responses
{
    public class CreateTransactionResponse : ICieloResponse
    {
        public string Content { get; private set; }
        public string Tid { get; private set; }
        public string AuthenticationUrl { get; private set; }

        public CreateTransactionResponse(string content)
        {
            Content = content;
            BindProperties();
        }

        private void BindProperties()
        {
            var document = XDocument.Parse(Content);
            
            var tidNode = document.Descendants(XName.Get("tid", "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (tidNode != null) Tid = tidNode.Value;

            var urlAuthenticationNode = document.Descendants(XName.Get("url-autenticacao", "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (urlAuthenticationNode != null) AuthenticationUrl = urlAuthenticationNode.Value;
        }
    }
}
