using System;
using System.Globalization;
using Awesomely.Extensions;
using Cielo.Configuration;
using Cielo.Extensions;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class CreateTransactionRequest : ICieloRequest
    {
        private readonly IConfiguration _configuration;
        private readonly PaymentMethod _paymentMethod;
        private readonly CreateTransactionOptions _options;
        private readonly Order _order;
        public Guid UniqueKey { get; set; }

        public CreateTransactionRequest(
                Order order,
                PaymentMethod paymentMethod,
                CreateTransactionOptions options,
                IConfiguration configuration = null)
        {
            if (configuration == null) configuration = new DefaultConfiguration();

            _configuration = configuration;
            _paymentMethod = paymentMethod;
            _options = options;
            _order = order;

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
                    c.numero(_configuration.CustomerId);
                    c.chave(_configuration.CustomerKey);
                }));

                req.dados_pedido(Xml.Fragment(c =>
                {
                    c.numero(_order.Id);
                    c.valor(_order.Total.ToCieloFormatValue());
                    c.moeda(_configuration.CurrencyId);
                    c.data_hora(_order.Date.ToCieloFormatDate());
                    c.descricao(_order.Description);
                    c.idioma(_configuration.Language.GetDescription());
                    c.soft_descriptor("");
                }));

                req.forma_pagamento(Xml.Fragment(c =>
                {
                    c.bandeira(_paymentMethod.CreditCard.GetDescription());
                    c.produto(_paymentMethod.PurchaseType.GetDescription());
                    c.parcelas(_paymentMethod.Installments);
                }));

                req.url_retorno(_configuration.ReturnUrl);
                req.autorizar((int)_options.AuthorizationType);
                req.capturar(_options.Capture.ToString(CultureInfo.InvariantCulture).ToLower());
                req.gerar_token(_options.GenerateToken.ToString(CultureInfo.InvariantCulture).ToLower());
            }));

            return xml.ToString(indent);
        }
    }
}