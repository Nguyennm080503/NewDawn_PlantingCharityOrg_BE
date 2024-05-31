using BussinessObjects.Models;

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
    }
}
