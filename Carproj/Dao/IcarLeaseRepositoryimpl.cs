using Carproj.Model;
using Carproj.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Dao
{
    internal class IcarLeaseRepositoryimpl : IcarLeaseRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public IcarLeaseRepositoryimpl()
        {
            sqlConnection = new SqlConnection(DbConUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        //Add car
        int IcarLeaseRepository.AddCar(Vehicle vehicle)
        {
            cmd.CommandText = "INSERT INTO Vehicle (vehicleid, make, model, year, dailyRate,status, passengerCapacity, engineCapacity) VALUES (@VehicleID, @Make, @Model, @Year, @DailyRate, @Status, @PassengerCapacity, @EngineCapacity)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleID);
            cmd.Parameters.AddWithValue("@Make", vehicle.Make);
            cmd.Parameters.AddWithValue("@Model", vehicle.Model);
            cmd.Parameters.AddWithValue("@Year", vehicle.Year);
            cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);
            cmd.Parameters.AddWithValue("@Status", vehicle.Status);
            cmd.Parameters.AddWithValue("@PassengerCapacity", vehicle.PassengerCapacity);
            cmd.Parameters.AddWithValue("@EngineCapacity", vehicle.EngineCapacity);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int CarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return CarStatus;

        }


        //get available cars
        public List<Vehicle> ListAvailableCars()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConUtil.GetConnectionString()))
            {
                cmd.CommandText = "select * from Vehicle WHERE Status='Available'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID = (int)reader["VehicleId"];
                    vehicle.Make = (string)reader["Make"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.DailyRate = (decimal)reader["DailyRate"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (decimal)reader["EngineCapacity"];
                    vehicles.Add(vehicle);





                }
                return vehicles;
            }
        }
        public List<Vehicle> ListRentedCars()
        {
            List<Vehicle> rentedvehicles = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConUtil.GetConnectionString()))
            {
                cmd.CommandText = "select * from Vehicle WHERE Status='NotAvailable'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID = (int)reader["VehicleId"];
                    vehicle.Make = (string)reader["Make"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.DailyRate = (decimal)reader["DailyRate"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (decimal)reader["EngineCapacity"];
                    rentedvehicles.Add(vehicle);





                }
                return rentedvehicles;


            }


        }

        //remove car and getcarby id remaining  


        //customer section 
        //Add customer
        int IcarLeaseRepository.AddCustomer(Customer customer)
        {
            cmd.CommandText = "INSERT INTO Customer(customerid,firstname, lastname, email, phonenumber) VALUES(@CustomerId , @FirstName,@LastName,@Email,@PhoneNumber)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
            cmd.Parameters.AddWithValue("@Firstname", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);


            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int CustomerStatus = cmd.ExecuteNonQuery();

            sqlConnection.Close();


            return CustomerStatus;



        }

        //List Customers

        public List<Customer> ListCustomer()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConUtil.GetConnectionString()))
            {
                cmd.CommandText = "select * from Customer";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)reader["CustomerId"];
                    customer.FirstName = (string)reader["Firstname"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Email = (string)reader["Email"];
                    customer.PhoneNumber = (string)reader["PhoneNumber"];
                    customers.Add(customer);






                }
                return customers;
            }
        }
        //getcustomerbyid and remove customer remaining


        //payment section 
        int IcarLeaseRepository.RecordPayment(Payment payment)
        {
           cmd.CommandText = "INSERT INTO Payment(paymentid,leaseid, paymentdate, amount) VALUES(@PaymentID ,@LeaseID,@PaymentDate,@Amount)";
            cmd.Parameters.Clear();/*
            cmd.Parameters.AddWithValue("@paymentId", payment.PaymentID);
            cmd.Parameters.AddWithValue("@leaseID", payment.LeaseID);
            cmd.Parameters.AddWithValue("@paymentDate", payment.PaymentDate);
            cmd.Parameters.AddWithValue("@amount", payment.Amount);*/

            cmd.Parameters.AddWithValue("@LeaseID", payment.LeaseID);
            cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Amount",payment.Amount);

           



            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int paymentStatus = cmd.ExecuteNonQuery();

            sqlConnection.Close();


            return paymentStatus;

          




        }

        int IcarLeaseRepository.UpdateCar(int VehicleID)
        {
            cmd.CommandText = "UPDATE Vehicle SET status = @status WHERE vehicleID = @VehicleID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CarID", VehicleID);
            cmd.Parameters.AddWithValue("@status", "notAvailable");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCarStatus;



        }


        //lease functionality 

        //lease history
        public List<Lease> LeaseHistory()
        {
            List<Lease> leases = new List<Lease>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConUtil.GetConnectionString()))
            {
                cmd.CommandText = "select * from Lease";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   Lease lease = new Lease();
                    lease.LeaseID = (int)reader["LeaseID"];
                    lease.VehicleID = (int)reader["VehicleID"];
                    lease.CustomerID = (int)reader["CustomerID"];
                    lease.StartDate = (DateTime)reader["StartDate"];
                    lease.EndDate = (DateTime)reader["EndDate"];
                    lease.TotalLeaseAmount = (int)reader["TotalLeaseAmount"];

                    lease.Type = (string)reader["Type"];   
                    leases.Add(lease);
                  





                }
                return leases;
            }
        }
        int IcarLeaseRepository.CreateLease(Lease lease)
        {
            cmd.CommandText = "INSERT INTO Lease (leaseID,  vehicleID, customerID,  startDate,  endDate,  type, totalLeaseAmount) VALUES (@LeaseID, @VehicleID, @CustomerID, @StartDate,@EndDate, @Type, @TotalLeaseAmount)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LeaseID", lease.LeaseID);
            cmd.Parameters.AddWithValue("@VehicleID",lease.VehicleID);
            cmd.Parameters.AddWithValue("@CustomerID", lease.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
            cmd.Parameters.AddWithValue("@Type", lease.Type);
            cmd.Parameters.AddWithValue("@TotalLeaseAmount", lease.TotalLeaseAmount);
            
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int LeaseStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return LeaseStatus;

        }

      /*  public List<Lease> GetActiveLease() {
            List<Lease> leases = new List<Lease>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConUtil.GetConnectionString()))
            {
                cmd.CommandText="SELECT "
                cmd.Connection=sqlConnection;
                sqlConnection.Open();

            }
        }
      */

       //findleasebyid

       
    }
}
