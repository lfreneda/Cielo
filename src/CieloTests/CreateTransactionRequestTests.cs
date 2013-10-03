using System;
using Awesomely.Extensions;
using Cielo.Enums;
using Cielo.Requests;
using Cielo.Requests.Entities;
using CieloTests.Configuration;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests {
    [TestFixture]
    public class CreateTransactionRequestTests {

        #region expected xml
        private const string ExpectedXmlCieloBuyPage = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <requisicao-transacao id=""b646a02f-9983-4df8-91b9-75b48345715a"" versao=""1.3.0"">
                                    <dados-ec>
                                        <numero>1001734898</numero>
                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                    </dados-ec>
                                    <dados-pedido>
                                        <numero>624726783</numero>
                                        <valor>1000</valor>
                                        <moeda>986</moeda>
                                        <data-hora>2013-02-18T16:45:12</data-hora>
                                        <descricao>[origem:172.16.34.66]</descricao>
                                        <idioma>PT</idioma>
                                        <soft-descriptor/>
                                    </dados-pedido>
                                    <forma-pagamento>
                                        <bandeira>visa</bandeira>
                                        <produto>1</produto>
                                        <parcelas>1</parcelas>
                                    </forma-pagamento>
                                    <url-retorno>http://localhost:7001/lojaexemplo-2.1/retorno.jsp</url-retorno>
                                    <autorizar>3</autorizar>
                                    <capturar>false</capturar>
                                    <gerar-token>false</gerar-token>
                                </requisicao-transacao>";

        private const string ExpectedXmlLojaBuyPage = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <requisicao-transacao id=""b646a02f-9983-4df8-91b9-75b48345715a"" versao=""1.3.0"">
                                    <dados-ec>
                                        <numero>1001734898</numero>
                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                    </dados-ec>
                                    <dados-portador>
                                        <numero>4551870000000183</numero>
                                        <validade>201508</validade>
                                        <indicador>1</indicador>
                                        <codigo-seguranca>973</codigo-seguranca>
                                        <token/>
                                    </dados-portador>
                                    <dados-pedido>
                                        <numero>624726783</numero>
                                        <valor>1000</valor>
                                        <moeda>986</moeda>
                                        <data-hora>2013-02-18T16:45:12</data-hora>
                                        <descricao>[origem:172.16.34.66]</descricao>
                                        <idioma>PT</idioma>
                                        <soft-descriptor/>
                                    </dados-pedido>
                                    <forma-pagamento>
                                        <bandeira>visa</bandeira>
                                        <produto>1</produto>
                                        <parcelas>1</parcelas>
                                    </forma-pagamento>
                                    <url-retorno>http://localhost:7001/lojaexemplo-2.1/retorno.jsp</url-retorno>
                                    <autorizar>3</autorizar>
                                    <capturar>false</capturar>
                                    <gerar-token>false</gerar-token>
                                </requisicao-transacao>";

        private const string ExpectedXmlLojaBuyPageWithoutSensitiveData = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <requisicao-transacao id=""b646a02f-9983-4df8-91b9-75b48345715a"" versao=""1.3.0"">
                                    <dados-ec>
                                        <numero>1001734898</numero>
                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                    </dados-ec>
                                    <dados-pedido>
                                        <numero>624726783</numero>
                                        <valor>1000</valor>
                                        <moeda>986</moeda>
                                        <data-hora>2013-02-18T16:45:12</data-hora>
                                        <descricao>[origem:172.16.34.66]</descricao>
                                        <idioma>PT</idioma>
                                        <soft-descriptor/>
                                    </dados-pedido>
                                    <forma-pagamento>
                                        <bandeira>visa</bandeira>
                                        <produto>1</produto>
                                        <parcelas>1</parcelas>
                                    </forma-pagamento>
                                    <url-retorno>http://localhost:7001/lojaexemplo-2.1/retorno.jsp</url-retorno>
                                    <autorizar>3</autorizar>
                                    <capturar>false</capturar>
                                    <gerar-token>false</gerar-token>
                                </requisicao-transacao>";
        #endregion

        [Test]
        public void ToXml_CieloBuyPage_GivenACreateTransactionRequest_ShouldGenerateAXmlAsExpected() {
            var order = new Order("624726783", 10.00m, new DateTime(2013, 02, 18, 16, 45, 12), "[origem:172.16.34.66]");
            var paymentMethod = new PaymentMethod(CreditCard.Visa, PurchaseType.Credit);
            var createTransactionOptions = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: false);
            var fakeConfiguration = new FakeConfiguration();

            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, createTransactionOptions, configuration: fakeConfiguration) {
                UniqueKey = Guid.Parse("b646a02f-9983-4df8-91b9-75b48345715a")
            };

            createTransactionRequest
                        .ToXml(indent: false)
                        .RemoveNewLinesAndSpaces()
                        .Should()
                        .Be(ExpectedXmlCieloBuyPage.RemoveNewLinesAndSpaces());
        }

        [Test]
        public void ToXml_LojaBuyPage_GivenACreateTransactionRequest_ShouldGenerateAXmlAsExpected() {
            var order = new Order("624726783", 10.00m, new DateTime(2013, 02, 18, 16, 45, 12), "[origem:172.16.34.66]");
            var paymentMethod = new PaymentMethod(CreditCard.Visa, PurchaseType.Credit);
            var createTransactionOptions = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: false);
            var creditCardData = new CreditCardData("4551870000000183", new CreditCardExpiration(2015, 08), SecurityCodeIndicator.Sent, 973);
            var fakeConfiguration = new FakeConfiguration();

            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, createTransactionOptions, creditCardData, fakeConfiguration) {
                UniqueKey = Guid.Parse("b646a02f-9983-4df8-91b9-75b48345715a")
            };

            createTransactionRequest
                        .ToXml(indent: false)
                        .RemoveNewLinesAndSpaces()
                        .Should()
                        .Be(ExpectedXmlLojaBuyPage.RemoveNewLinesAndSpaces());
        }

        [Test]
        public void ToXmlWithoutSensitiveData_GivenACreateTransactionRequest_ShouldGenerateAXmlWithoutSensitiveDataAkaCreditCardNumberAndDateAndSecurityCode() {

            var order = new Order("624726783", 10.00m, new DateTime(2013, 02, 18, 16, 45, 12), "[origem:172.16.34.66]");
            var paymentMethod = new PaymentMethod(CreditCard.Visa, PurchaseType.Credit);
            var createTransactionOptions = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: false);
            var creditCardData = new CreditCardData("4551870000000183", new CreditCardExpiration(2015, 08), SecurityCodeIndicator.Sent, 973);
            var fakeConfiguration = new FakeConfiguration();

            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, createTransactionOptions, creditCardData, fakeConfiguration) {
                UniqueKey = Guid.Parse("b646a02f-9983-4df8-91b9-75b48345715a")
            };

            createTransactionRequest
                .ToXmlWithoutSensitiveData(indent: false)
                .RemoveNewLinesAndSpaces()
                .Should()
                .Be(ExpectedXmlLojaBuyPageWithoutSensitiveData.RemoveNewLinesAndSpaces());
        }
    }
}
