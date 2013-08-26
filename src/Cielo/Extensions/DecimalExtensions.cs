using System;

namespace Cielo.Extensions
{
    public static class DecimalExtensions
    {
        public static int ToCieloFormatValue(this decimal value)
        {
            var n2Value = value.ToString("N2");
            var formatedValue = n2Value.Replace(".", "").Replace(",", "");
            return Convert.ToInt32(formatedValue);
        }
    }
}
