using BussinessObjects.Models;
using DTOS.PaymentDetail;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class PaymentTransactionDetailDAO : BaseDAO<PaymentTransactionDetail>
    {
        private static PaymentTransactionDetailDAO _instance = null;
        private readonly DataContext dataContext;
        private static readonly object _lock = new object();

        private PaymentTransactionDetailDAO()
        {
            dataContext = new DataContext();
        }

        public static PaymentTransactionDetailDAO Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PaymentTransactionDetailDAO();
                    }
                }
                return _instance;
            }
        }


        public async Task<IEnumerable<TopOrdersView>> GetTopOrdersViewAsync()
        {
            var payment = await dataContext.PaymentTransactionDetail
                .Include(x => x.PaymentTransaction)
                .Where(v => v.PaymentTransaction.Status == 0)
                .GroupBy(y => y.PaymentTransaction.AccountID)
                .Select(a => new TopOrdersView
                {
                    AccountID = a.Key,
                    Username = dataContext.UserInformation.FirstOrDefault(t => t.AccountID == a.Key).Username,
                    Quantity = a.Sum(t => t.Quantity)
                }).OrderByDescending(g => g.Quantity).Take(10).ToListAsync();

            return payment;
        }

        public async Task<IEnumerable<NewOrdersView>> GetNewOrdersViewAsync()
        {
            var payment = await dataContext.PaymentTransactionDetail
                .Include(x => x.PaymentTransaction)
                .Where(v => v.PaymentTransaction.Status == 0)
                .OrderByDescending(y => y.PaymentTransaction.DateCreate)
                .Select(a => new NewOrdersView
                {
                    AccountID = a.PaymentTransaction.AccountID,
                    Username = dataContext.UserInformation.FirstOrDefault(t => t.AccountID == a.PaymentTransaction.AccountID).Username,
                    Quantity = a.Quantity,
                    DateOrder = a.PaymentTransaction.DateCreate
                }).Take(10).ToListAsync();

            return payment;
        }

        public int GetQuantityTransaction(int transactionID)
        {
            return dataContext.PaymentTransactionDetail.FirstOrDefaultAsync(x => x.PaymentID == transactionID).Result.Quantity;
        }
    }
}
