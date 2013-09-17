namespace Cielo.Responses.Exceptions
{
    public class ErrorResponse : CieloResponse<ErrorResponse>
    {
        public ErrorResponse(string content)
            : base(content)
        {
            Map(c => c.Id, "codigo");
            Map(c => c.Message, "mensagem");
        }

        public string Id { get; set; }
        public string Message { get; set; }
    }
}