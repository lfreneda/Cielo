using Cielo.Requests;
using Cielo.Responses;

namespace Cielo
{
    public interface ICieloService
    {
        CreateTransactionResponse CreateTransaction(CreateTransactionRequest request);
        CheckTransactionResponse CheckTransaction(CheckTransactionRequest request);
        CancelTransactionResponse CancelTransaction(CancelTransactionRequest request);
    }
}