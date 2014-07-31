using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using Awesomely.Extensions;
using RestSharp.Extensions;

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

            MemberExpression memberExpression = null;

            if (propertyExpression.Body.NodeType == ExpressionType.Convert)
                memberExpression = ((UnaryExpression) propertyExpression.Body).Operand as MemberExpression;
            else if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess)
                memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null || memberExpression.Member == null)
                throw new ArgumentNullException("propertyExpression", "Not a member access!");

            var propertyName = (memberExpression.Member as PropertyInfo).Name;

            var value = (converter != null) ? converter.Convert(node.Value) : node.Value;
            if (this.GetType().GetProperty(propertyName) == null) return;
            this.GetType().GetProperty(propertyName).SetValue(this, value, null);
        }
    }
}