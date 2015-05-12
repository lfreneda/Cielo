using Cielo.Requests;
using Cielo.Requests.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class CreditCardExpirationTests
    {
        [Test]
        public void ToString_GivenACreditCardWithYeat2013AndMonth05_ShouldReturnStringFormatedYYYYMM()
        {
            var expiration = new CreditCardExpiration(2013, 05);
            expiration.ToString().Should().Be("201305");
        }
    }
}
