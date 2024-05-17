using Carproj.Dao;
using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal class CustomerService:IcustomerService
    {
        readonly IcarLeaseRepository _repository;
        public CustomerService()
        {

            _repository = new IcarLeaseRepositoryimpl();
        }
        public void AddCustomer()
        {


            Console.WriteLine("Enter Customer details:");
            Console.WriteLine("CustomerId: ");
            int CustomerId = int.Parse(Console.ReadLine());

            Console.Write("FirstName: ");
            string firstname = Console.ReadLine();

            Console.Write("LastName: ");
            string lastname = Console.ReadLine();

            Console.Write("Email: ");
            string email = (Console.ReadLine());

            Console.Write("PhoneNumber: ");
            string phonenumber = (Console.ReadLine());


            Customer customer1 = new Customer(CustomerId, firstname, lastname, email, phonenumber);
            CustomerService customerService = new CustomerService();
            _repository.AddCustomer(customer1);
            



        }

        //list customers

        public List<Customer> ListCustomer()
        {
            List<Customer> list = _repository.ListCustomer();
            if (list == null)
            {
                Console.WriteLine("No Customers at the moment");
            }
            Console.WriteLine("Customers");
            return list;
        }

    }
}
