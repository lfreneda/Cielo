using System;
using Cielo.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        /*
         * Em todas as mensagens a data/hora deverá seguir o formato: aaaa-MM-ddTHH24:mm:ss. 
         * Exemplo: 2011-12-21T11:32:45
         */

        [Test]
        public void ToCieloFormatDate_GivenADate_ShouldReturnInCieloFormat()
        {
            var transactionDate = new DateTime(2011, 12, 21, 11, 32, 45);
            transactionDate.ToCieloFormatDate().Should().Be("2011-12-21T11:32:45");
        }

        [Test]
        public void ToCieloFormatDate_Given20111221_ShouldReturnInCieloFormat()
        {
            var transactionDate = new DateTime(1988, 05, 15, 23, 01, 08);
            transactionDate.ToCieloFormatDate().Should().Be("1988-05-15T23:01:08");
        }

    }
}