using Carproj.Dao;
using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal class LeaseService : IleaseService
    {
        readonly IcarLeaseRepository _repository;

        public LeaseService()
        {
            _repository = new IcarLeaseRepositoryimpl();
        }
        public List<Lease> LeaseHistory()
        {
            List<Lease> list = _repository.LeaseHistory();
            if (list == null)
            {
                Console.WriteLine("No History Available ");
            }
            Console.WriteLine("Available Lease History");
            return list;
        }

        public void CreateLease()
        {
            try
            {
                Console.WriteLine("Enter Lease details:");
                Console.WriteLine("LeaseId: ");
                int leaseid = int.Parse(Console.ReadLine());

                Console.Write("VehicleId: ");
                int vehicleid = int.Parse(Console.ReadLine());

                Console.Write("CustomerId: ");
                int customerid = int.Parse(Console.ReadLine());

                Console.Write("Startdate: ");
                DateTime startdate = DateTime.Parse(Console.ReadLine());

                Console.Write("EndDate: ");
                DateTime enddate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Type:");
                string type = Console.ReadLine();

                Console.Write("TotalLeaseAmount: ");
                int totalleaseamount = int.Parse(Console.ReadLine());


                Lease lease = new Lease(leaseid, vehicleid, customerid, startdate, enddate, type, totalleaseamount);
                LeaseService leaseService = new LeaseService();
                _repository.CreateLease(lease);


                Console.WriteLine("LeaseAdded");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

      

    }
}

