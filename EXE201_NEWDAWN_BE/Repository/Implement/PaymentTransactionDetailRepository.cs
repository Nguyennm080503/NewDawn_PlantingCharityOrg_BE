using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.PaymentDetail;
using Repository.Interface;

namespace Repository.Implement
{
    public class PaymentTransactionDetailRepository : IPaymentTransactionDetailRepository
    {
        private readonly IMapper mapper;

        public PaymentTransactionDetailRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<int> CreatePaymentTransactionDetail(PaymentDetailCreate paymentTransactionDetail)
        {
            var paymentdetail = mapper.Map<PaymentTransactionDetail>(paymentTransactionDetail);
            await PaymentTransactionDetailDAO.Instance.CreateAsync(paymentdetail);
            return paymentdetail.PaymentDetailID;
        }

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
