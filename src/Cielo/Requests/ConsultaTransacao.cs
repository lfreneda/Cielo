using System;
using Cielo.Configuration;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class ConsultaTransacao : ICieloRequest
    {
        private readonly string _tid;
        private readonly IConfiguracao _configuration;

        public ConsultaTransacao(string tid, IConfiguracao configuracao = null)
        {
            if (configuracao == null) configuracao = new ConfiguracaoDefault();
            _configuration = configuracao;

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
                    c.numero(_configuration.NumeroEstabelecimento);
                    c.chave(_configuration.ChaveEstabelecimento);
                }));

            }));

            return xml.ToString(indent);
        }
    }
}