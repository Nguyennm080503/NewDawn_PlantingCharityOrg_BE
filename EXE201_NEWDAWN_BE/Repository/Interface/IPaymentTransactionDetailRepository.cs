using DTOS.PaymentDetail;

namespace Repository.Interface
{
    public interface IPaymentTransactionDetailRepository
    {
        Task<IEnumerable<TopOrdersView>> GetTopOrdersViewAsync();
        Task<IEnumerable<NewOrdersView>> GetNewOrdersViewAsync();
    }
}
