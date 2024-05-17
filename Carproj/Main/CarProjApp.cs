using Carproj.Dao;
using Carproj.Model;
using Carproj.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Main
{
    internal class CarProjApp
    {

        readonly IvehicleService _vehicleService;
        readonly IleaseService _leaseService;
        readonly IpaymentService _paymentService;
        readonly IcustomerService _customerService;
        public CarProjApp()
        {
        }

        public CarProjApp(IcarLeaseRepository repository)
        {
            _customerService = new CustomerService();
            _vehicleService = new VehicleService();
            _paymentService = new PaymentService();
            _leaseService = new LeaseService();




        }



        public void run()
        {

        }
    }
}