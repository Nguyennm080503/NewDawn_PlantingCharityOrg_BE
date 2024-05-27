using BussinessObjects.Models;

namespace DAO
{
    internal class PaymentTransactionDetailDAO : BaseDAO<PaymentTransactionDetail>
    {
        private static PaymentTransactionDetailDAO instance = null;
        private readonly DataContext dataContext;

        private PaymentTransactionDetailDAO()
        {
            dataContext = new DataContext();
        }

        public static PaymentTransactionDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentTransactionDetailDAO();
                }
                return instance;
            }
        }
    }
}
