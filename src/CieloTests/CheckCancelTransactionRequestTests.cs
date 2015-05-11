using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Requests;
using CieloTests.Configuration;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CieloTests
{
 
    [TestFixture]
    public class CheckCancelTransactionRequestTests
    {
        private const string ExpectedXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                                <requisicao-cancelamento id=""4c38f150-b67d-4059-88d1-b53b13e54a8e"" versao=""1.3.0"">
                                                    <tid>10069930690864271001</tid>
                                                    <dados-ec>
                                                        <numero>1001734898</numero>
                                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                                    </dados-ec>
                                                </requisicao-cancelamento>";

        [Test]
        public void ToXml_GivenACancelTransactionRequest_ShouldGenerateAXmlAsExpected()
        {
            var cancelTransactionRequest = new CancelTransactionRequest("10069930690864271001", new FakeConfiguration())
            {
                UniqueKey = Guid.Parse("4c38f150-b67d-4059-88d1-b53b13e54a8e")
            };

            cancelTransactionRequest
                            .ToXml(indent: false)
                            .RemoveNewLinesAndSpaces()
                            .Should()
                            .Be(ExpectedXml.RemoveNewLinesAndSpaces());
        }
    }
}
