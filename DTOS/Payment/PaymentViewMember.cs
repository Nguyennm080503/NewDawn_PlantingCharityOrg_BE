using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Payment
{
    public class PaymentViewMember
    {
        public int TransactionID { get; set; }
        public string TransactionCode { get; set; }
        public string AccountBank { get; set; }
        public string AccountName { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public double TotalAmout { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }
    }
}
