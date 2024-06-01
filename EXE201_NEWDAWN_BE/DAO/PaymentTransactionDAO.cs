using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class PaymentTransactionDAO : BaseDAO<PaymentTransaction>
    {
        private static PaymentTransactionDAO _instance = null;
        private readonly DataContext dataContext;
        private static readonly object _lock = new object();

        private PaymentTransactionDAO()
        {
            dataContext = new DataContext();
        }

        public static PaymentTransactionDAO Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PaymentTransactionDAO();
                    }
                }
                return _instance;
            }
        }

        public async Task<IEnumerable<PaymentTransaction>> Get4PaymentTransaction()
        {
            return await dataContext.PaymentTransaction.Include(x => x.UserInformation).OrderByDescending(x => x.DateCreate).Take(6).ToListAsync();
        }
        public async Task<IEnumerable<PaymentTransaction>> GetAllPayments()
        {
            return await dataContext.PaymentTransaction.Include(x => x.UserInformation).OrderByDescending(x => x.DateCreate).ToListAsync();
        }
        public async Task<double> GetTotalProfit()
        {
            return dataContext.PaymentTransaction.Sum(x => x.TotalAmout);
        }
    }
}
