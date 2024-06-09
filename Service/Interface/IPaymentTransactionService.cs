using BussinessObjects.Models;
using DTOS.Payment;

namespace Service.Interface
{
    public interface IPaymentTransactionService
    {
        Task<int> CreatePaymentTransaction(PaymentTransaction paymentTransaction);
        Task<IEnumerable<Top4Transaction>> Top4Transactions();
        Task<IEnumerable<PaymentAdminView>> GetAllTransactions();
        Task<IEnumerable<PaymentViewMember>> GetAllTransactionOfMember(int accountID);
    }
}
