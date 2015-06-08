using Cielo.Enums;

namespace Cielo.Responses
{
    public class CheckTransactionResponse : CieloResponse<CheckTransactionResponse>
    {
        public CheckTransactionResponse(string content)
            : base(content)
        {
            Status = Status.Default;
            Map(c => c.Status, "status", new EnumStatusConverter());
        }

        public Status Status { get; set; }
    }
}