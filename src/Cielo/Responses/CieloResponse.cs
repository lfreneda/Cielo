using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using Awesomely.Extensions;

namespace Cielo.Responses
{
    public class CieloResponse<T> : ICieloResponse
    {
        private readonly XDocument _xdocument;
        public string Content { get; private set; }

        protected CieloResponse(string content)
        {
            Content = content;
            _xdocument = XDocument.Parse(Content);
        }

        public void Map(Expression<Func<T, object>> propertyExpression, string xmlNodeName, IPropertyFromXmlConverter converter = null)
        {
            var node = _xdocument.Descendants(XName.Get(xmlNodeName, "http://ecommerce.cbmp.com.br")).FirstOrDefault();
            if (node == null) return;

            var left = propertyExpression.GetMember();
            if (left == null) return;
            var propertyName = left.Member.Name;

            var value = (converter != null) ? converter.Convert(node.Value) : node.Value;
            this.SetPropertyValue(value, propertyName);
        }
    }
}