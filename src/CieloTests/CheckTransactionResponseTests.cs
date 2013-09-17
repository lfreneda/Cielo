using Cielo.Enums;
using Cielo.Responses;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class CheckTransactionResponseTests
    {
        private const string XmlResponse = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
                                                        <transacao versao=""1.3.0"" id=""0dcb285b-fbb2-491c-ac58-d49e3b8b97c3"" xmlns=""http://ecommerce.cbmp.com.br"">
                                                          <tid>1001734898001D871001</tid>
                                                          <dados-pedido>
                                                            <numero>624726783</numero>
                                                            <valor>1000</valor>
                                                            <moeda>986</moeda>
                                                            <data-hora>2013-08-27T18:04:31.345-03:00</data-hora>
                                                            <descricao>[origem:172.16.34.66]</descricao>
                                                            <idioma>PT</idioma>
                                                            <taxa-embarque>0</taxa-embarque>
                                                          </dados-pedido>
                                                          <forma-pagamento>
                                                            <bandeira>visa</bandeira>
                                                            <produto>1</produto>
                                                            <parcelas>1</parcelas>
                                                          </forma-pagamento>
                                                          <status>0</status>
                                                        </transacao>";

        [Test]
        public void GivenAResponseXml_ShouldGetStatusEqualToCreated()
        {
            var checkTransactionResponse = new CheckTransactionResponse(XmlResponse);
            checkTransactionResponse.Status.Should().Be(Status.Created);
        }
    }
}