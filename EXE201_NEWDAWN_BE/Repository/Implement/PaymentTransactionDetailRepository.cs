using DAO;
using DTOS.PaymentDetail;
using Repository.Interface;

namespace Repository.Implement
{
    public class PaymentTransactionDetailRepository : IPaymentTransactionDetailRepository
    {
        public async Task<IEnumerable<NewOrdersView>> GetNewOrdersViewAsync()
        {
            var orders = await PaymentTransactionDetailDAO.Instance.GetNewOrdersViewAsync();
            return orders;
        }

        public async Task<IEnumerable<TopOrdersView>> GetTopOrdersViewAsync()
        {
            var orders = await PaymentTransactionDetailDAO.Instance.GetTopOrdersViewAsync();
            return orders;
        }
    }
}
