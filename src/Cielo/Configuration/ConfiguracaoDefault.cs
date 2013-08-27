using System;
using System.Configuration;
using Cielo.Enums;

namespace Cielo.Configuration
{
    public class ConfiguracaoDefault : IConfiguracao
    {
        public string ChaveEstabelecimento
        {
            get { return ConfigurationManager.AppSettings["cielo.estabelecimento.chave"]; }
        }

        public string NumeroEstabelecimento
        {
            get { return ConfigurationManager.AppSettings["cielo.estabelecimento.numero"]; }
        }

        public string UrlRetorno
        {
            get { return ConfigurationManager.AppSettings["cielo.url.retorno"]; }
        }

        public Idioma Idioma
        {
            get { return (Idioma)Convert.ToInt32(ConfigurationManager.AppSettings["cielo.idioma.id"]); }
        }

        public string MoedaId
        {
            get { return ConfigurationManager.AppSettings["cielo.moeda.id"]; }
        }
    }
}