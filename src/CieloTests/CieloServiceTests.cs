using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cielo;
using Cielo.Requests;
using Cielo.Responses;
using Cielo.Responses.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class CieloServiceTests
    {
        public class CieloServiceFake : CieloService
        {
            public CieloServiceFake()
                : base("http://endpoint.fake.br")
            {
            }

            public string ReturnXml { get; set; }
            protected override string Execute(ICieloRequest cieloRequest)
            {
                return ReturnXml;
            }
        }

        [Test]
        public void CreateTransaction_WhenXmlResponseDoesNotContainError_ShouldReturnCreateTransactionResponse()
        {
            var service = new CieloServiceFake()
            {
                ReturnXml = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
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
                                                        </transacao>"
            };

            var response = service.CreateTransaction(new CreateTransactionRequest(null, null, null));
            response.Should().BeOfType<CreateTransactionResponse>();
        }

        [Test]
        public void CreateTransaction_WhenXmlResponseContainError_ShouldThrowsResponseException()
        {
            var service = new CieloServiceFake()
            {
                ReturnXml = @"<erro xmlns=""http://ecommerce.cbmp.com.br"">
                                  <codigo>014</codigo>
                                  <mensagem>Autorização Direta é permitida apenas para crédito.</mensagem>
                              </erro>"
            };

            Assert.That(() => service.CreateTransaction(new CreateTransactionRequest(null, null, null)),
                Throws
                .Exception
                .TypeOf<ResponseException>()
                .With.Property("Message")
                .EqualTo("Autorização Direta é permitida apenas para crédito."));
        }

        [Test]
        public void CheckTransaction_WhenXmlResponseContainError_ShouldThrowsResponseExeception()
        {
            var service = new CieloServiceFake()
            {
                ReturnXml = @"<erro xmlns=""http://ecommerce.cbmp.com.br"">
                                  <codigo>014</codigo>
                                  <mensagem>Autorização Direta é permitida apenas para crédito.</mensagem>
                              </erro>"
            };

            Assert.That(() => service.CheckTransaction(new CheckTransactionRequest("Tid")),
                Throws
                .Exception
                .TypeOf<ResponseException>()
                .With.Property("Message")
                .EqualTo("Autorização Direta é permitida apenas para crédito."));
        }

        [Test]
        public void CheckTransaction_WhenXmlResponseDoesNotContainError_ShouldReturnCheckTransactionResponse()
        {
            var service = new CieloServiceFake()
            {
                ReturnXml = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
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
                                                        </transacao>"
            };

            var response = service.CheckTransaction(new CheckTransactionRequest("Tid"));
            response.Should().BeOfType<CheckTransactionResponse>();
        }
    }


}
