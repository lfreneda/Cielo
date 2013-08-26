using System;

namespace Cielo.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCieloFormatDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
}