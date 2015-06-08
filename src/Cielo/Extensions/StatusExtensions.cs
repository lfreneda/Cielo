using System;
using Cielo.Enums;

namespace Cielo.Extensions
{
    public static class StatusExtensions
    {
        public static Status ToStatus(this string str)
        {
            var enumCode = Convert.ToInt32(str);
            return enumCode.ToStatus();
        }

        public static Status ToStatus(this int enumCode)
        {
            return (Status) enumCode;
        }
    }
}