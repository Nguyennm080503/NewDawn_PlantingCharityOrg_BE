using BussinessObjects.Models;
using DTOS.Payment;

namespace Repository.Interface
{
    public interface IPaymentTransactionRepository
    {
        Task<int> CreatePaymentTransaction(PaymentTransaction paymentTransaction);
        Task<IEnumerable<Top4Transaction>> Top4Transactions();
        Task<IEnumerable<PaymentAdminView>> GetAllTransactions();
        Task<double> GetTotalProfit();
        Task<double> GetTotalProfitEachMonth();
        Task<IEnumerable<PaymentViewMember>> GetAllTransactionOfMember(int accountID);
    }
}
