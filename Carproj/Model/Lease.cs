using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Model
{
    internal class Lease
    {
        public int LeaseID { get; set; }


        public int VehicleID { get; set; }


        public int CustomerID { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public string Type { get; set; }

        public int TotalLeaseAmount { get; set; }

        public Lease()
        {

        }
        public Lease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type, int totalLeaseAmount)
        {
            LeaseID = leaseID;
            VehicleID = vehicleID;
            CustomerID = customerID;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
            TotalLeaseAmount = totalLeaseAmount;
        }
        public override string ToString()
        {
            return $"LeaseId:{LeaseID},VehicleID:{VehicleID},CustomerID:{CustomerID},StartDate:{StartDate},EndDate:{EndDate},Type:{Type},TotalLeaseAmount:{TotalLeaseAmount}";
        }
    }

}

