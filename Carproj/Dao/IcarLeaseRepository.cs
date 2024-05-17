using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Dao
{
    internal interface IcarLeaseRepository
    {
        int AddCar(Vehicle vehicle);
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();

        int AddCustomer(Customer customer);
        List<Customer> ListCustomer();
        int RecordPayment(Payment payment);
      
        int UpdateCar(int VehicleID);
        List<Lease> LeaseHistory();
        int  CreateLease(Lease lease);
        
       
    }
}
