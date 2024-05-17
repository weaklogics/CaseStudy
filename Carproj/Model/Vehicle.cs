using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Model
{
    internal class Vehicle
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal EngineCapacity { get; set; }
        public Vehicle()
        {

        }
        public Vehicle(int vehicleiD, string make, string model, int year, decimal dailyrate, string status, int passengercapacity, decimal enginecapacity)
        {
            VehicleID = vehicleiD;

            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyrate;
            Status = status;
            PassengerCapacity = passengercapacity;
            EngineCapacity = enginecapacity;


        }
        public override string ToString()
        {
            return $"VehiclId:{VehicleID},Make:{Make}, Model:{Model}, Year:{Year},DailyRate:{DailyRate},Status:{Status},PassengerCapacity:{PassengerCapacity},EngineCapacity:{EngineCapacity}";

        }
    }
}
