namespace Cielo.Enums
{
    public enum TipoAutorizacao
    {
        NaoAutorizar = 0,
        AutorizarSomenteSeAutenticada = 1,
        AutorizarAutenticadaENaoAutenticada = 2,
        AutorizarSemPassarPorAutenticacao = 3,
        TransacaoRecorrente = 4
    }
}