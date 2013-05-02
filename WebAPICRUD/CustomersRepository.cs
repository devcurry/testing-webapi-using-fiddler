using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICRUD
{
    public class CustomersRepository
    {
        public static List<Customer> GetAllCustomers()
        {
            SampleDBEntities dataContext=new SampleDBEntities();
            var query = from customer in dataContext.Customers
                        select customer;
            return query.ToList();
        }
        public static Customer GetCustomer(string customerID)
        {
            SampleDBEntities dataContext=new SampleDBEntities();
            var query = (from customer in dataContext.Customers
                         where customer.CustomerID==customerID
                         select customer).SingleOrDefault();
            return query;
        }
        public static void InsertCustomer(Customer newCustomer)
        {
            SampleDBEntities dataContext = new SampleDBEntities();
            dataContext.Customers.Add(newCustomer);
            dataContext.SaveChanges();
        }
        public static void UpdateCustomer(Customer oldCustomer)
        {
            SampleDBEntities dataContext = new SampleDBEntities();
            var query = (from customer in dataContext.Customers
                         where customer.CustomerID==oldCustomer.CustomerID
                         select customer).SingleOrDefault();
            query.CustomerID = oldCustomer.CustomerID;
            query.ContactName = oldCustomer.ContactName;
            query.City = oldCustomer.City;
            dataContext.SaveChanges();
        }
        public static void DeleteCustomer(string customerID)
        {
            SampleDBEntities dataContext = new SampleDBEntities();
            var query = (from customer in dataContext.Customers
                         where customer.CustomerID == customerID
                         select customer).SingleOrDefault();
            dataContext.Customers.Remove(query);
            dataContext.SaveChanges();
        }
    }
}