using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB.IRepo
{
    public interface IOrderRepo
    {
        void NewOrder(OrderModel order);
        //OrderModel OldOrder(int customerId, int locationId);
        void AddProductToOrderItem(OrderItemModel order);
        void DeleteProductFromOrderItem(OrderItemModel order);

        void DeleteOrder(OrderModel order);
        void PlaceOrder(OrderModel order);
        int GetOrderId(CustomerModel customerid, int locationId);

        void ChangeOrderTotalPrice(OrderModel order, decimal amount);
    
        OrderModel GetCurrentOrder(int customerid, int locationid);
        
        List<OrderItemModel> GetItemsInBasket(int orderid);
        
    }
}