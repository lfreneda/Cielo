using System.Globalization;

namespace Cielo.Requests.Entities
{
    public class CreditCardExpiration
    {
        private readonly short _year;
        private readonly byte _month;

        public CreditCardExpiration(short year, byte month)
        {
            _year = year;
            _month = month;
        }

        public override string ToString()
        {
            var monthAsString = _month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            return string.Format("{0}{1}", _year, monthAsString);
        }
    }
}