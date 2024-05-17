using Carproj.Dao;
using Carproj.Main;
using Carproj.Model;
using Carproj.Services;

namespace Carproj
{
     class Program
    {
        static void Main(string[] args)
        {
            IcarLeaseRepository leaseRepository = new IcarLeaseRepositoryimpl();
          LeaseService leaseService = new LeaseService();
            leaseService.CreateLease();
            /*
            CustomerService customerService = new CustomerService();
             customerService.AddCustomer();
             PaymentService paymentService = new PaymentService();
             paymentService.RecordPayment();*/

           /*IcarLeaseRepository leaseRepository = new IcarLeaseRepositoryimpl();
            List<Lease> allleases = leaseRepository.LeaseHistory(); 
            foreach (Lease lease in allleases)
            {
                Console.WriteLine(lease);
            }
           

            CustomerService customerService = new CustomerService();*/
            

           /* CarProjApp carProj = new CarProjApp();
            carProj.run();*/
        }
    }

}
