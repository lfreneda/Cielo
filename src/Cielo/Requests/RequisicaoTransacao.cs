using System.Globalization;
using Awesomely.Extensions;
using Cielo.Configuration;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class RequisicaoTransacao : IRequestXml
    {
        private readonly IConfiguracao _configuration;
        private readonly FormaPagamento _formaPagamento;
        private readonly RequisicaoTransacaoOpcoes _opcoes;

        public RequisicaoTransacao(
                FormaPagamento formaPagamento,
                RequisicaoTransacaoOpcoes opcoes, 
                IConfiguracao configuration = null)
        {
            if (configuration == null) configuration = new ConfiguracaoDefault();
            _configuration = configuration;
            _formaPagamento = formaPagamento;
            _opcoes = opcoes;
        }

        public string ToXml(bool indent = false)
        {
            dynamic xml = new Xml { UseDashInsteadUnderscore = true };
            xml.Declaration(encoding: "ISO-8859-1");
            xml.requisicao_transacao(new { id = "b646a02f-9983-4df8-91b9-75b48345715a", versao = "1.3.0" }, Xml.Fragment(req =>
            {
                req.dados_ec(Xml.Fragment(c =>
                {
                    c.numero(_configuration.NumeroEstabelecimento);
                    c.chave(_configuration.ChaveEstabelecimento);
                }));

                req.dados_pedido(Xml.Fragment(c =>
                {
                    c.numero("624726783");
                    c.valor("1000");
                    c.moeda(_configuration.MoedaId);
                    c.data_hora("2013-02-18T16:45:12");
                    c.descricao("[origem:172.16.34.66]");
                    c.idioma(_configuration.Idioma.GetDescription());
                    c.soft_descriptor("");
                }));

                req.forma_pagamento(Xml.Fragment(c =>
                {
                    c.bandeira(_formaPagamento.Bandeira.GetDescription());
                    c.produto(_formaPagamento.TipoDaVenda.GetDescription());
                    c.parcelas(_formaPagamento.Parcelas);
                }));

                req.url_retorno(_configuration.UrlRetorno);
                req.autorizar((int)_opcoes.TipoAutorizacao);
                req.capturar(_opcoes.Capturar.ToString(CultureInfo.InvariantCulture).ToLower());
                req.gerar_token(_opcoes.GerarToken.ToString(CultureInfo.InvariantCulture).ToLower());
            }));

            return xml.ToString(indent);
        }
    }
}