using Cielo.Configuration;
using Cielo.Enums;

namespace CieloTests.Configuration
{
    public class CustomConfiguration : IConfiguracao
    {
        public string ChaveEstabelecimento { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public string UrlRetorno { get; set; }
        public Idioma Idioma { get; set; }
        public string MoedaId { get; set; }
    }
}