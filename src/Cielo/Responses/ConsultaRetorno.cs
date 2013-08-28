using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using Cielo.Enums;
using Cielo.Extensions;

namespace Cielo.Responses
{
    public class ConsultaRetorno : ICieloResponse
    {
        public string Content { get; set; }
        public Status Status { get; set; }

        public ConsultaRetorno(string content) {
            Content = content;
            Status = Status.SemStatus;
            BindProperties();
        }

        private void BindProperties() {
            var document = XDocument.Parse(Content);
            var statusNode = document.Descendants(XName.Get("status", "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (statusNode != null) Status = statusNode.Value.ToStatus();
        }
    }
}
