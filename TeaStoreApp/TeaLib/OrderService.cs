using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class OrderService
    {
        
        private DBRepo repo;

        public OrderService(){
            this.repo = new DBRepo();
        }


        public void NewOrder(int customerId, int locationId){
            repo.NewOrder(customerId, locationId);
        }

        public bool OldOrder(int customerId, int locationId){
            return repo.OldOrder(customerId,locationId);
        }
        public void DeleteOrder(int orderid){
            repo.DeleteOrder(orderid);
        }
        public void PlaceOrder(int orderid){
            repo.PlaceOrder(orderid);
        }
        public int GetOrderId(int customerid, int locationId){
            return repo.GetOrderId(customerid,locationId);
        }
        
    }
}