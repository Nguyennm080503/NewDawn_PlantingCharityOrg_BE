using BussinessObjects.Models;
using DTOS.Payment;
using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        public PaymentTransactionService(IPaymentTransactionRepository paymentTransactionRepository) 
        {
            _paymentTransactionRepository = paymentTransactionRepository;
        }

        public async Task<int> CreatePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            return await _paymentTransactionRepository.CreatePaymentTransaction(paymentTransaction);
        }

        public async Task<IEnumerable<PaymentViewMember>> GetAllTransactionOfMember(int accountID)
        {
            return await _paymentTransactionRepository.GetAllTransactionOfMember(accountID);
        }

        public async Task<IEnumerable<PaymentAdminView>> GetAllTransactions()
        {
            return await _paymentTransactionRepository.GetAllTransactions();
        }

        public async Task<IEnumerable<Top4Transaction>> Top4Transactions()
        {
            return await _paymentTransactionRepository.Top4Transactions();
        }
    }
}
