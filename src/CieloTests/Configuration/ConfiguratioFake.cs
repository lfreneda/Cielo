using Cielo.Configuration;
using Cielo.Enums;

namespace CieloTests.Configuration
{
    public class ConfiguratioFake : IConfiguracao
    {
        public string ChaveEstabelecimento
        {
            get { return "e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832"; }
        }
        public string NumeroEstabelecimento
        {
            get { return "1001734898"; }
        }
        public string UrlRetorno
        {
            get { return "http://localhost:7001/lojaexemplo-2.1/retorno.jsp"; }
        }
        public Idioma Idioma
        {
            get { return Idioma.Portugues; }
        }
        public string MoedaId
        {
            get { return "986"; }
        }
    }
}
