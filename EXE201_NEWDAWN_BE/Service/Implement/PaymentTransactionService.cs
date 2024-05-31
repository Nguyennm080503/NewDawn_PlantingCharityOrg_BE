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

        public async Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction)
        {
            return await _paymentTransactionRepository.CreatePaymentTransaction(paymentTransaction);
        }
    }
}
