using System;
using Cielo.Configuration;
using DynamicBuilder;

namespace Cielo.Requests
{
    public class CancelTransactionRequest : CieloRequest
    {
        private readonly string _tid;

        public CancelTransactionRequest(string tid, IConfiguration configuration = null)
            : base(configuration)
        {
            _tid = tid;
            UniqueKey = Guid.NewGuid();
        }

        public Guid UniqueKey { get; set; }

        public override string ToXml(bool indent)
        {
            dynamic xml = new Xml { UseDashInsteadUnderscore = true };
            xml.Declaration(encoding: "ISO-8859-1");

            xml.requisicao_cancelamento(new { id = UniqueKey, versao = CieloVersion.Version }, Xml.Fragment(req =>
            {
                req.tid(_tid);
                Affiliate.ToXml(req, Configuration);
            }));

            return xml.ToString(indent);
        }
    }
}