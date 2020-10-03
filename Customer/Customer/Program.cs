using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement
{
    public class Customer
    {

        public Customer(int customerid, string name, string address, int salary)
        {
            CustomerID = customerid;
            Name = name;
            Address = address;
            Salary = salary;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
    }
    interface ICustomerManager
    {
        bool Add(Customer cust);
        bool Remove(int id);
        bool Update(int id);
        bool GetAll();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customer> customers = new HashSet<Customer>();
        public bool Add(Customer cust)
        {
            return customers.Add(cust);
        }

        public bool Remove(int id)
        {
            foreach (Customer cust in customers)
            {
                if (cust.CustomerID == id)
                {
                    customers.Remove(cust);
                    return true;
                }
            }
            return false;
        }
        public bool Update(int id)
        {
            foreach (Customer cust in customers)
            {
                if (cust.CustomerID == id)
                {
                    Console.Write("Enter the new name: ");
                    string newname = Console.ReadLine();
                    Console.Write("Enter the new address: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Enter the new salary: ");
                    int newsalary = int.Parse(Console.ReadLine());
                    cust.Name = newname;
                    cust.Address = newaddress;
                    cust.Salary = newsalary;
                    return true;
                }
            }
            return false;
        }
        public bool GetAll()
        {
            foreach (var cust in customers)
            {
                Console.WriteLine($"ID: {cust.CustomerID}");
                Console.WriteLine($"Name: {cust.Name}");
                Console.WriteLine($"Address: {cust.Address}");
                Console.WriteLine($"Salary: {cust.Salary}");
            }
            return true;
        }
    }

    class CustomerManagerDemo
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer(101, "Amita", "Cochin", 300);
            Customer c2 = new Customer(102, "Ria", "Mysore", 400);
            Customer c3 = new Customer(103, "Urja", "Bhubaneswar", 500);
            CustomerManager manager = new CustomerManager();
            manager.Add(c1);
            manager.Add(c2);
            manager.Add(c3);

            manager.GetAll();
            manager.Remove(102);
            manager.GetAll();
        }

    }
}