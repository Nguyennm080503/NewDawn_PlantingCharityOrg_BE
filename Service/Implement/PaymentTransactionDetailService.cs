using DTOS.PaymentDetail;
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

        public async Task<int> CreatePaymentTransactionDetail(PaymentDetailCreate paymentTransactionDetail)
        {
            return await _paymentTransactionDetailRepository.CreatePaymentTransactionDetail(paymentTransactionDetail);
        }

        public async Task<IEnumerable<NewOrdersView>> GetNewOrdersViewAsync()
        {
            return await _paymentTransactionDetailRepository.GetNewOrdersViewAsync();
        }

        public async Task<IEnumerable<TopOrdersView>> GetTopOrdersViewAsync()
        {
            return await _paymentTransactionDetailRepository.GetTopOrdersViewAsync();
        }
    }
}
