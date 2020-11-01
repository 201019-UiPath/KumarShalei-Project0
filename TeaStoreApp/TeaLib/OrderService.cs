using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class OrderService
    {
        
        private IOrderRepo repo;

        public OrderService(IOrderRepo repo){
            this.repo = repo;
        }


        public void NewOrder(OrderModel order){
            repo.NewOrder(order);
        }

        public bool OldOrder(int customerId, int locationId){
            return repo.OldOrder(customerId,locationId);
        }
        public void DeleteOrder(OrderModel order){
            repo.DeleteOrder(order);
        }
        public void PlaceOrder(OrderModel order){
            repo.PlaceOrder(order);
        }
        public int GetOrderId(int customerid, int locationId){
            return repo.GetOrderId(customerid,locationId);
        }
        
    }
}