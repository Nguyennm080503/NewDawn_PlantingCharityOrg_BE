using DTOS.Payment;

namespace Service.Interface
{
    public interface IPaymentTransactionService
    {
        Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction);
        Task<IEnumerable<Top4Transaction>> Top4Transactions();
        Task<IEnumerable<PaymentAdminView>> GetAllTransactions();
    }
}
