using System;
using Cielo.Configuration;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class CheckTransactionRequest : ICieloRequest
    {
        private readonly string _tid;
        private readonly IConfiguration _configuration;

        public CheckTransactionRequest(string tid, IConfiguration configuration = null)
        {
            if (configuration == null) configuration = new DefaultConfiguration();
            _configuration = configuration;

            _tid = tid;
            UniqueKey = Guid.NewGuid();
        }

        public Guid UniqueKey { get; set; }

        public string ToXml(bool indent)
        {
            dynamic xml = new Xml { UseDashInsteadUnderscore = true };
            xml.Declaration(encoding: "ISO-8859-1");

            xml.requisicao_consulta(new { id = UniqueKey, versao = "1.3.0" }, Xml.Fragment(req =>
            {
                req.tid(_tid);

                req.dados_ec(Xml.Fragment(c =>
                {
                    c.numero(_configuration.CustomerId);
                    c.chave(_configuration.CustomerKey);
                }));

            }));

            return xml.ToString(indent);
        }
    }
}