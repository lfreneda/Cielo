using Cielo.Enums;

namespace Cielo.Responses
{
    public class CancelTransactionResponse : CieloResponse<CheckTransactionResponse>
    {
        public Status Status { get; set; }

        public CancelTransactionResponse(string content)
            : base(content)
        {
            Status = Status.Default;
            Map(c => c.Status, "status", new EnumStatusConverter());
        }
    }
}
