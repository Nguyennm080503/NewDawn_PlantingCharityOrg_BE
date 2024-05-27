using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PaymentTransactionDetailService : IPaymentTransactionDetailService
    {
        private readonly IPaymentTransactionDetailRepository _paymentTransactionDetailRepository;

        public PaymentTransactionDetailService(IPaymentTransactionDetailRepository paymentTransactionDetailRepository)
        {
            _paymentTransactionDetailRepository = paymentTransactionDetailRepository;
        }
    }
}
