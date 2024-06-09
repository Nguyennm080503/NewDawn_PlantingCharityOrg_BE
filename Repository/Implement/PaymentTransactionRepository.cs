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

        public async Task<int> CreatePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            await PaymentTransactionDAO.Instance.CreateAsync(paymentTransaction);
            return paymentTransaction.TransactionID;
        }

        public async Task<IEnumerable<PaymentViewMember>> GetAllTransactionOfMember(int accountID)
        {
            var payments = PaymentTransactionDAO.Instance.GetAllPayments().Result.Where(x => x.AccountID == accountID);
            return mapper.Map<IEnumerable<PaymentViewMember>>(payments);
        }

        public async Task<IEnumerable<PaymentAdminView>> GetAllTransactions()
        {
            var payments = await PaymentTransactionDAO.Instance.GetAllPayments();
            return mapper.Map<IEnumerable<PaymentAdminView>>(payments);
        }

        public async Task<double> GetTotalProfit()
        {
            return await PaymentTransactionDAO.Instance.GetTotalProfit();
        }

        public async Task<double> GetTotalProfitEachMonth()
        {
            DateTime datenow = DateTime.Now;
            int month = datenow.Month;
            int year = datenow.Year;
            return await PaymentTransactionDAO.Instance.GetTotalProfitEachMonth(month, year);
        }

        public async Task<IEnumerable<Top4Transaction>> Top4Transactions()
        {
            var payments = await PaymentTransactionDAO.Instance.Get4PaymentTransaction();
            var transactions = payments.Select(x => new Top4Transaction
            {
                TransactionID = x.TransactionID,
                Username = x.UserInformation.Username,
                Email = x.UserInformation.Email,
                Quantity = PaymentTransactionDetailDAO.Instance.GetQuantityTransaction(x.TransactionID),
                DateCreate = x.DateCreate
            }).ToList();
            return transactions;
        }
    }
}
