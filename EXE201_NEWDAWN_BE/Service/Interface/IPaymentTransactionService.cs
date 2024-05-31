using DTOS.Payment;

namespace Service.Interface
{
    public interface IPaymentTransactionService
    {
        Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction);
    }
}
