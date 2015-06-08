using Cielo.Enums;

namespace Cielo.Responses
{
    public class CancelTransactionResponse : CieloResponse<CheckTransactionResponse>
    {
        public CancelTransactionResponse(string content)
            : base(content)
        {
            Status = Status.Default;
            Map(c => c.Status, "status", new EnumStatusConverter());
        }

        public Status Status { get; set; }
    }
}