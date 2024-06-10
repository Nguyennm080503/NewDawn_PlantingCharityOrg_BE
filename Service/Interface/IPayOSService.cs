using DTOS;
using Net.payOS.Types;


namespace Service.Interface
{
    public interface IPayOSService
    {
        Task<string> CreatePaymentLink(int quantity, string urlCanecl, string urlReturn);
        Task<TransactionReturn> HandleCodeAfterPaymentQR(int code);
        Task<Transaction> Test(int code);
        Task<string> paymentLinkResSignature(long orderId);
        Task<string> getPaymentLinkInformation(long orderId);
    }
}
