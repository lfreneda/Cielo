using Cielo.Enums;

namespace Cielo
{
    public class RequisicaoTransacaoOpcoes
    {
        public TipoAutorizacao TipoAutorizacao { get; private set; }
        public bool Capturar { get; private set; }
        public bool GerarToken { get; private set; }

        public RequisicaoTransacaoOpcoes(
            TipoAutorizacao tipoAutorizacao,
            bool capturar = false,
            bool gerarToken = false)
        {
            TipoAutorizacao = tipoAutorizacao;
            Capturar = capturar;
            GerarToken = gerarToken;
        }
    }
}