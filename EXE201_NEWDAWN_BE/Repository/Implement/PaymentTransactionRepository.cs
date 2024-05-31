using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.Payment;
using Repository.Interface;

namespace Repository.Implement
{
    public class PaymentTransactionRepository : IPaymentTransactionRepository
    {
        private readonly IMapper mapper;

        public PaymentTransactionRepository(IMapper mapper) 
        {
            this.mapper = mapper;
        }

        public async Task<int> CreatePaymentTransaction(PaymentCreate paymentTransaction)
        {
            var payment = mapper.Map<PaymentTransaction>(paymentTransaction);
            payment.Status = 0;
            payment.DateCreate = DateTime.Now;
            await PaymentTransactionDAO.Instance.CreateAsync(payment);
            return payment.TransactionID;
        }
    }
}
