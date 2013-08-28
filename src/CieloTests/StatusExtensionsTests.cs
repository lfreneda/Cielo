using Cielo.Enums;
using Cielo.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class StatusExtensionsTests
    {
        /*
         *  Status da Transação        Código
         *  =================================
         *  Transação Criada ...............0
         *  Transação em Andamento .........1
         *  Transação Autenticada ..........2
         *  Transação não Autenticada ......3
         *  Transação Autorizada ...........4
         *  Transação não Autorizada .......5
         *  Transação Capturada ............6
         *  Transação Cancelada ............9
         *  Transação em Autenticação .....10
         *  Transação em Cancelamento .....12
         */

        [TestCase("0", Status.Criada)]
        [TestCase("1", Status.EmAndamento)]
        [TestCase("2", Status.Autenticada)]
        [TestCase("3", Status.NaoAutenticada)]
        [TestCase("4", Status.Autorizada)]
        [TestCase("5", Status.NaoAutorizada)]
        [TestCase("6", Status.Capturada)]
        [TestCase("9", Status.Cancelada)]
        [TestCase("10", Status.EmAutenticacao)]
        [TestCase("12", Status.EmCancelamento)]
        public void GivenStringCodeAsString_ShouldResultInStatusExpected(string statusCodeAsString, Status statusExpected)
        {
            statusCodeAsString.ToStatus().Should().Be(statusExpected);
        }

        [TestCase(0, Status.Criada)]
        [TestCase(1, Status.EmAndamento)]
        [TestCase(2, Status.Autenticada)]
        [TestCase(3, Status.NaoAutenticada)]
        [TestCase(4, Status.Autorizada)]
        [TestCase(5, Status.NaoAutorizada)]
        [TestCase(6, Status.Capturada)]
        [TestCase(9, Status.Cancelada)]
        [TestCase(10, Status.EmAutenticacao)]
        [TestCase(12, Status.EmCancelamento)]
        public void GivenStringCodeAsString_ShouldResultInStatusExpected(int statusCodeAsInt, Status statusExpected)
        {
            statusCodeAsInt.ToStatus().Should().Be(statusExpected);
        }
    }
}
