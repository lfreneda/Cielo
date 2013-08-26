using Cielo.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests.Extensions
{
    [TestFixture]
    public class DecimalExtensionsTests
    {
        /*
         * Os valores monetários são sempre tratados como valores inteiros, sem representação das casas decimais.
         * Sendo que os dois últimos dígitos são considerados como os centavos. 
         * Exemplo: R$ 1.286,87 é representado como 128687; R$ 1,00 é representado como 100
         */

        [Test]
        public void ToCieloFormatValue_128687m_ShouldResultIn128687()
        {
            const decimal transactionValue = 1286.87m;
            transactionValue.ToCieloFormatValue().Should().Be(128687);
        }

        [Test]
        public void ToCieloFormatValue_4040m_ShouldResultIn404000()
        {
            const decimal transactionValue = 4040m;
            transactionValue.ToCieloFormatValue().Should().Be(404000);
        }

        [Test]
        public void ToCieloFormatValue_4_ShouldReturnIn400()
        {
            const decimal transactionValue = 4m;
            transactionValue.ToCieloFormatValue().Should().Be(400);
        }
    }
}