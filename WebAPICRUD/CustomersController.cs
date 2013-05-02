using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPICRUD
{
    public class CustomersController : ApiController
    {
        public List<Customer> Get()
        {
            return CustomersRepository.GetAllCustomers();
        }

        public Customer Get(string id)
        {
            return CustomersRepository.GetCustomer(id);
        }

        public void Post([FromBody]Customer customer)
        {
            CustomersRepository.InsertCustomer(customer);
        }

        public void Put([FromBody]Customer customer)
        {
            CustomersRepository.UpdateCustomer(customer);
        }

        public void Delete(string id)
        {
            CustomersRepository.DeleteCustomer(id);
        }
    }
}