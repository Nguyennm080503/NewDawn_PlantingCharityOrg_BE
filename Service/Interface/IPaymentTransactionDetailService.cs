using DTOS.PaymentDetail;

namespace Service.Interface
{
    public interface IPaymentTransactionDetailService
    {
        Task<IEnumerable<TopOrdersView>> GetTopOrdersViewAsync();
        Task<IEnumerable<NewOrdersView>> GetNewOrdersViewAsync();
        Task<int> CreatePaymentTransactionDetail(PaymentDetailCreate paymentTransactionDetail);
    }
}
