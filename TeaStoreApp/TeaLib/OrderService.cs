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


        public void NewOrder(int customerId, int locationId, decimal price){
            OrderModel order = new OrderModel(){
                customerId = customerId,
                locationId = locationId,
                totalPrice = price
            };
            repo.NewOrder(order);
        }

        public OrderModel GetCurrentOrder(int customerId, int locationId){
            return repo.GetCurrentOrder(customerId,locationId);
        }

        public void AddProductToOrderList(int orderid, int productid, int amount, decimal price){
            OrderItemModel order = new OrderItemModel(){
                orderId = orderid,
                productId = productid,
                amount = amount,
                totalPrice = price
            };
            repo.AddProductToOrderItem(order);
        }
        public void DeleteProductFromOrderItem(int orderid, int productid){
            
            repo.DeleteProductFromOrderItem(orderid, productid);
        }

        public List<OrderItemModel> GetItemsInBasket(int orderid){
            return repo.GetItemsInBasket(orderid);
        }

        public void DeleteOrder(int orderid){
            repo.DeleteOrder(orderid);
        }

        public int GetOrderId(CustomerModel customer, int locationId){

            return repo.GetOrderId(customer,locationId);
        }


        public void PlaceOrder(OrderModel order){
            repo.PlaceOrder(order);
        }


        // public ProductModel GetProductFunFact(int id){
        //     return repo.GetProductFunFact(id);
        // }


        public void DecreaseStock(InventoryModel inventory, int productid, int stock){
            repo.DecreaseStock(inventory, productid, stock);
        }

        public void ChangeOrderTotalPrice(int orderid, decimal amount){
            repo.ChangeOrderTotalPrice(orderid,amount);
        }
        public ProductModel GetProduct(int productid){
            return repo.GetProduct(productid);
        }



        
    }
}