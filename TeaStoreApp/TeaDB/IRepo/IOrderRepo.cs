using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB.IRepo
{
    public interface IOrderRepo
    {
        void NewOrder(OrderModel order);
        void AddProductToOrderItem(OrderItemModel order);
        void DeleteProductFromOrderItem(int orderid, int productid);


        void DecreaseStock(InventoryModel inventory, int productid, int stock);
        void DeleteOrder(int orderid);
        void PlaceOrder(OrderModel order);
        int GetOrderId(CustomerModel customerid, int locationId);

        void ChangeOrderTotalPrice(int orderid, decimal amount);
    
        OrderModel GetCurrentOrder(int customerid, int locationid);
        
        List<OrderItemModel> GetItemsInBasket(int orderid);

        ProductModel GetProduct(int productid);

        //int GetOrderItemid(int orderid, int productid);
        
    }
}