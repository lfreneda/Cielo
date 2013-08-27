using Cielo.Enums;

namespace Cielo.Configuration
{
    public interface IConfiguracao
    {
        string ChaveEstabelecimento { get; }
        string NumeroEstabelecimento { get; }
        string UrlRetorno { get; }
        Idioma Idioma { get; }
        string MoedaId { get; }
    }
}