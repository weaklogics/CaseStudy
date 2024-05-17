using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal interface IvehicleService
    {
        void AddCar();
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();

    }
}
