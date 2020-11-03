using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    
    public class CustomerService
    {


        private DBRepo repo;
        public CustomerService(){
            this.repo = new DBRepo();
        }

        public void AddCustomer(string firstName, string lastName, string email){
            CustomerModel customer = new CustomerModel(){
                firstName = firstName,
                lastName = lastName,
                email = email
            };
            repo.NewCustomerAsync(customer);
            
        }

        public CustomerModel GetCustomerInfo(string email){
            return repo.GetCustomerInfo(email);
        }

        public List<OrderModel> GetOrderHistory(CustomerModel customer){
            return repo.GetOrderHistory(customer);
        }

    }
 
    
}