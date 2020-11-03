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

        public void AddCustomer(CustomerModel customer){
            
            repo.NewCustomerAsync(customer);
            System.Threading.Thread.Sleep(5);
            
        }

        public CustomerModel GetCustomerInfo(string email){
            return repo.GetCustomerInfo(email);
        }

        public List<OrderModel> GetOrderHistory(CustomerModel customer){
            return repo.GetOrderHistory(customer);
        }

    }
 
    
}