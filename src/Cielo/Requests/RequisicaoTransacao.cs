using System;
using System.Globalization;
using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Extensions;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class RequisicaoTransacao : IRequestXml
    {
        private readonly IConfiguracao _configuration;
        private readonly FormaPagamento _formaPagamento;
        private readonly RequisicaoTransacaoOpcoes _opcoes;
        private readonly Pedido _pedido;
        public Guid UniqueKey { get; set; }

        public RequisicaoTransacao(
                Pedido pedido,
                FormaPagamento formaPagamento,
                RequisicaoTransacaoOpcoes opcoes,
                IConfiguracao configuracao = null)
        {
            if (configuracao == null) configuracao = new ConfiguracaoDefault();
            _configuration = configuracao;
            _formaPagamento = formaPagamento;
            _opcoes = opcoes;
            _pedido = pedido;

            UniqueKey = Guid.NewGuid();
        }

        public string ToXml(bool indent = false)
        {
            dynamic xml = new Xml { UseDashInsteadUnderscore = true };
            xml.Declaration(encoding: "ISO-8859-1");
            xml.requisicao_transacao(new { id = UniqueKey, versao = "1.3.0" }, Xml.Fragment(req =>
            {
                req.dados_ec(Xml.Fragment(c =>
                {
                    c.numero(_configuration.NumeroEstabelecimento);
                    c.chave(_configuration.ChaveEstabelecimento);
                }));

                req.dados_pedido(Xml.Fragment(c =>
                {
                    c.numero(_pedido.Id);
                    c.valor(_pedido.Valor.ToCieloFormatValue());
                    c.moeda(_configuration.MoedaId);
                    c.data_hora(_pedido.Data.ToCieloFormatDate());
                    c.descricao(_pedido.Descricao);
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