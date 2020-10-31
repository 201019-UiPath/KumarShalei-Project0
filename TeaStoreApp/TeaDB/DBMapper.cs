using System.Collections.Generic;
using TeaDB.Entities;
using TeaDB.Models;

namespace TeaDB
{
    public class DBMapper : ICustomerMapper
    {
        public Customers ParseCustomer(CustomerModel customer)
        {
            return new Customers(){
                Customername = customer.name
            };
        }

        public ICollection<Customers> ParseCustomer(List<CustomerModel> customer)
        {
            ICollection<Customers> customers = new List<Customers>();
            foreach (var c in customer){

                customers.Add(ParseCustomer(c));
            }
            return customers;
        }

        public CustomerModel ParseCustomer(Customers customer)
        {
            return new CustomerModel(){
                id = customer.Customerid,
                name = customer.Customername
            };
        }

        public List<CustomerModel> ParseCustomer(ICollection<Customers> customer)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            foreach (var c in customer){
                customers.Add(ParseCustomer(c));
            }
            return customers;
        }
    }
}
