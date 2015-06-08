using Cielo.Responses.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class ResponseErrorTests
    {
        private const string XmlResponse = @"<erro xmlns=""http://ecommerce.cbmp.com.br"">
                                                <codigo>014</codigo>
                                                <mensagem>Autorização Direta é permitida apenas para crédito.</mensagem>
                                            </erro>";
        private ErrorResponse _errorResponse;

        [SetUp]
        public void SetUp()
        {
            _errorResponse = new ErrorResponse(XmlResponse);
        }

        [Test]
        public void GivenAResponseXml_IdShouldBeEqualTo014()
        {
            _errorResponse.Id.Should().Be("014");
        }

        [Test]
        public void GivenAResponseXml_MessageShouldBeEqualToAutorizacaoDiretaÉPermitidaApenasParaCrédito()
        {
            _errorResponse.Message.Should().Be("Autorização Direta é permitida apenas para crédito.");
        }
    }
}