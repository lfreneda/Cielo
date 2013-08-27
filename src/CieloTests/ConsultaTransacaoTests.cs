using System;
using Awesomely.Extensions;
using Cielo.Requests;
using CieloTests.Fake;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    [TestFixture]
    public class ConsultaTransacaoTests
    {
        private const string ExpectedXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                                <requisicao-consulta id=""4c38f150-b67d-4059-88d1-b53b13e54a8e"" versao=""1.3.0"">
                                                    <tid>10069930690864271001</tid>
                                                    <dados-ec>
                                                        <numero>1001734898</numero>
                                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                                    </dados-ec>
                                                </requisicao-consulta>";

        [Test]
        public void ToXml_ShouldGenerateAXmlAsExpected()
        {
            var consultaTransacao = new ConsultaTransacao("10069930690864271001", new ConfiguratioFake())
            {
                UniqueKey = Guid.Parse("4c38f150-b67d-4059-88d1-b53b13e54a8e")
            };
            consultaTransacao
                .ToXml(indent: false)
                .RemoveNewLinesAndSpaces()
                .Should()
                .Be(ExpectedXml.RemoveNewLinesAndSpaces());
        }
    }
}