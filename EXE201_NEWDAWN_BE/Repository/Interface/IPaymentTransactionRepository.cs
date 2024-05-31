using BussinessObjects.Models;
using DTOS.Payment;

namespace Repository.Interface
{
    public interface IPaymentTransactionRepository
    {
        Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction);
    }
}
