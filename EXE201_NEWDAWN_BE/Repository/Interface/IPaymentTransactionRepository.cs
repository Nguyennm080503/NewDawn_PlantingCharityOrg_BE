using DTOS.Payment;

namespace Repository.Interface
{
    public interface IPaymentTransactionRepository
    {
        Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction);
        Task<IEnumerable<Top4Transaction>> Top4Transactions();
        Task<IEnumerable<PaymentAdminView>> GetAllTransactions();
        Task<double> GetTotalProfit();
    }
}
