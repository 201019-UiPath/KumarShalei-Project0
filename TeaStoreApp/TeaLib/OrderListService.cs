using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class OrderListService
    {

        private DBRepo repo;
        public OrderListService(){
            this.repo = new DBRepo();
        }

        public void AddProductToOrderList(OrderListModel order){
            repo.AddProductToOrderList(order);
        }
        public void DeleteProductFromOrderList(int productid,int orderid){
            repo.DeleteProductFromOrderList(productid,orderid);
        }
        public List<OrderListModel> GetItemsInBasket(int orderid){
            return repo.GetItemsInBasket(orderid);
        }
    
    }
}