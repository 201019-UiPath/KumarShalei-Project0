using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class OrderListService
    {

        private IOrderListRepo repo;
        public OrderListService(IOrderListRepo repo){
            this.repo = repo;
        }

        public void AddProductToOrderList(OrderListModel order){
            repo.AddProductToOrderList(order);
        }
        public void DeleteProductFromOrderList(OrderListModel order){
            repo.DeleteProductFromOrderList(order);
        }
        public List<OrderListModel> GetItemsInBasket(int orderid){
            return repo.GetItemsInBasket(orderid);
        }
    
    }
}