using Cielo.Responses;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class CreateTransactionResponseTests
    {
        private const string ExpectedResponse = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
                                    <transacao versao=""1.3.0"" id=""af32f93c-5e9c-4f44-9478-ccc5aca9319e"" xmlns=""http://ecommerce.cbmp.com.br"">
                                        <tid>100699306908642F1001</tid>
                                        <pan>uv9yI5tkhX9jpuCt+dfrtoSVM4U3gIjvrcwMBfZcadE=</pan>
                                        <dados-pedido>
                                            <numero>2132385784</numero>
                                            <valor>1000</valor>
                                            <moeda>986</moeda>
                                            <data-hora>2013-02-18T16:51:30.852-03:00</data-hora>
                                            <descricao>[origem:0:0:0:0:0:0:0:1]</descricao>
                                            <idioma>PT</idioma>
                                            <taxa-embarque>0</taxa-embarque>
                                        </dados-pedido>
                                        <forma-pagamento>
                                            <bandeira>visa</bandeira>
                                            <produto>1</produto>
                                            <parcelas>1</parcelas>
                                        </forma-pagamento>
                                        <status>4</status>
                                        <autenticacao>
                                            <codigo>4</codigo>
                                            <mensagem>Transacao sem autenticacao</mensagem>
                                            <data-hora>2013-02-18T16:51:31.158-03:00</data-hora>
                                            <valor>1000</valor>
                                            <eci>7</eci>
                                        </autenticacao>
                                        <autorizacao>
                                            <codigo>4</codigo>
                                            <mensagem>Transação autorizada</mensagem>
                                            <data-hora>2013-02-18T16:51:31.460-03:00</data-hora>
                                            <valor>1000</valor>
                                            <lr>00</lr>
                                            <arp>123456</arp>
                                            <nsu>549935</nsu>
                                        </autorizacao>
                                        <url-autenticacao>https://ecommerce.cielo.com.br/web/index.cbmp?id=a783251</url-autenticacao>
                                    </transacao>";
        private CreateTransactionResponse _createTransactionResponse;

        [SetUp]
        public void SetUp()
        {
            _createTransactionResponse = new CreateTransactionResponse(ExpectedResponse);
        }

        [Test]
        public void GivenAXmlReponse_TidShouldBeEqualtTo100699306908642F1001()
        {
            _createTransactionResponse.Tid.Should().Be("100699306908642F1001");
        }

        [Test]
        public void GivenAXmlResponse_UrlAuthenticationShouldBeAsExpected()
        {
            _createTransactionResponse.AuthenticationUrl.Should()
                .Be("https://ecommerce.cielo.com.br/web/index.cbmp?id=a783251");
        }

        [Test]
        public void GivenAXmlResponse_PanShouldBeAsExpected()
        {
            _createTransactionResponse.Pan.Should().Be("uv9yI5tkhX9jpuCt+dfrtoSVM4U3gIjvrcwMBfZcadE=");
        }

        [Test]
        public void ToString_ShouldFormatTidAndPan()
        {
            _createTransactionResponse.ToString()
                .Should()
                .Be("Tid: 100699306908642F1001, Pan: uv9yI5tkhX9jpuCt+dfrtoSVM4U3gIjvrcwMBfZcadE=");
        }
    }
}