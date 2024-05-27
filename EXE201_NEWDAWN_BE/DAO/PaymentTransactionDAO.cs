using BussinessObjects.Models;

namespace DAO
{
    public class PaymentTransactionDAO : BaseDAO<PaymentTransaction>
    {
        private static PaymentTransactionDAO instance = null;
        private readonly DataContext dataContext;

        private PaymentTransactionDAO()
        {
            dataContext = new DataContext();
        }

        public static PaymentTransactionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentTransactionDAO();
                }
                return instance;
            }
        }
    }
}
