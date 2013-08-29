using Cielo.Enums;

namespace Cielo.Responses
{
    public class CheckTransactionResponse : CieloResponse<CheckTransactionResponse>
    {
        public Status Status { get; set; }

        public CheckTransactionResponse(string content)
            : base(content)
        {
            Status = Status.Default;
            Map(c => c.Status, "status", new EnumStatusConverter());
        }
    }
}
