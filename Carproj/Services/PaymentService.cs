using Carproj.Dao;
using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal class PaymentService : IpaymentService
    {
        readonly IcarLeaseRepository _carLeaseRepository;
        public PaymentService()
        {
            _carLeaseRepository = new IcarLeaseRepositoryimpl();
        }
        public void RecordPayment()
        {


            Console.WriteLine("Enter Payment details:");
            Console.WriteLine("PaymentId: ");
           int paymentid = int.Parse(Console.ReadLine());

            Console.Write("LeaseId: ");
            int leaseid = int.Parse(Console.ReadLine());

            Console.Write("PaymentDate: ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());


            Console.Write("PaymentAmount: ");
           decimal amount = decimal.Parse(Console.ReadLine());

            ;


            Payment payment = new Payment(paymentid,leaseid,paymentDate, amount);
            PaymentService paymentService = new PaymentService();

        }
    }
}
