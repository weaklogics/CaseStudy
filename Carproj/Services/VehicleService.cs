using Carproj.Dao;
using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal class VehicleService : IvehicleService
    {
        readonly IcarLeaseRepository _repository;

        public VehicleService()
        {
            _repository = new IcarLeaseRepositoryimpl();
        }
        //only carfunctionalities

        public void AddCar()
        {

            try
            {

                Console.WriteLine("Enter Vehicle details:");
                Console.WriteLine("VehicleId: ");
                int vehicleid = int.Parse(Console.ReadLine());

                Console.Write("Make: ");
                string make = Console.ReadLine();

                Console.Write("Model: ");
                string model = Console.ReadLine();

                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Daily Rate: ");
                decimal dailyRate = decimal.Parse(Console.ReadLine());

                Console.Write("Status : ");
                string status = Console.ReadLine();



                Console.Write("Passenger Capacity: ");
                int passengerCapacity = int.Parse(Console.ReadLine());

                Console.Write("Engine Capacity: ");
                int engineCapacity = int.Parse(Console.ReadLine());
                Vehicle vehicle = new Vehicle(vehicleid, make, model, year, dailyRate, status, passengerCapacity, engineCapacity);
                VehicleService vehicleService = new VehicleService();
                _repository.AddCar(vehicle);

                Console.WriteLine("Car Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Car not added some issue occured");
            }
        }

        //All Available Cars 
        public List<Vehicle> ListAvailableCars()
        {
            List<Vehicle> list = _repository.ListAvailableCars();
            if (list == null)
            {
                Console.WriteLine("No Cars Available at the moment");
            }
            Console.WriteLine("Available cars");
            return list;
        }

        //All Rented Cars or NotAvailable 
        public List<Vehicle> ListRentedCars()
        {
            List<Vehicle> list = _repository.ListRentedCars();
            if (list == null)
            {
                Console.WriteLine("No Cars on Rent at the moment");
            }
            Console.WriteLine("Rented  cars");
            return list;
        }
        

    }
}