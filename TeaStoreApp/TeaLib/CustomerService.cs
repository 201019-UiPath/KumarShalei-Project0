using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    // public delegate void CustomerDel();
    
    public class CustomerService
    {
    //     public event CustomerDel newCustomer;
    //     public event CustomerDel placedOrder;

        private ICustomerRepo repo;
        public CustomerService(ICustomerRepo repo){
            this.repo = repo;
        }

        public void AddCustomer(CustomerModel customer){
            repo.NewCustomerAsync(customer);
        }

        public CustomerModel GetCustomer(int customerId){
            return repo.GetCustomer(customerId);
        }

        public List<OrderModel> GetOrderHistory(int customerId){
            return repo.GetOrderHistory(customerId);
        }

    }
 
    
}