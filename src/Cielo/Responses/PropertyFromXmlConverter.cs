using Cielo.Extensions;

namespace Cielo.Responses
{
    public class EnumStatusConverter : IPropertyFromXmlConverter
    {
        public object Convert(string value)
        {
            return value.ToStatus();
        }
    }
}