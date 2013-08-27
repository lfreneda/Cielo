using Cielo.Enums;

namespace Cielo
{
    public class FormaPagamento
    {
        public Bandeira Bandeira { get; private set; }
        public TipoVenda TipoDaVenda { get; private set; }
        public int Parcelas { get; private set; }

        public FormaPagamento(Bandeira bandeira, TipoVenda tipoDaVenda, int parcelas = 1)
        {
            Bandeira = bandeira;
            TipoDaVenda = tipoDaVenda;
            Parcelas = parcelas;
        }
    }
}