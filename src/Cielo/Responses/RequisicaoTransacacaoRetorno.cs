using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Awesomely.Extensions;

namespace Cielo.Responses
{
    public interface ICieloResponse
    {
        string Content { get; }
    }

    public class RequisicaoTransacacaoRetorno : ICieloResponse
    {
        public string Content { get; private set; }
        public string Tid { get; private set; }
        public string UrlAutenticacao { get; private set; }

        public RequisicaoTransacacaoRetorno(string content)
        {
            Content = content;
            BuildProperties();
        }

        private void BuildProperties()
        {
            var document = XDocument.Parse(Content);
            
            var tidNode = document.Descendants(XName.Get("tid", "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (tidNode != null) Tid = tidNode.Value;

            var urlAuthenticationNode = document.Descendants(XName.Get("url-autenticacao", "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (urlAuthenticationNode != null) UrlAutenticacao = urlAuthenticationNode.Value;
        }
    }
}
