using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Model
{
    internal class Payment
    {

        public int PaymentID { get; set; }

        public int LeaseID { get; set; }


        public DateTime PaymentDate { get; set; }


        public decimal Amount { get; set; }

        public Payment()
        {

        }
        public Payment(int paymentID, int leaseID, DateTime paymentDate, decimal amount)
        {
            PaymentID = paymentID;
            LeaseID = leaseID;
            PaymentDate = paymentDate;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"PaymentID:{PaymentID},LeaseID:{LeaseID},Amount:{Amount}";
        }
    }
}
