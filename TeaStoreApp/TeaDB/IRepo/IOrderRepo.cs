using TeaDB.Entities;
using TeaDB.Models;

namespace TeaDB.IRepo
{
    public interface IOrderRepo
    {
        void NewOrder(OrderModel order);
        bool OldOrder(int customerId, int locationId);
        void DeleteOrder(int orderid);
        void PlaceOrder(int orderid);
        int GetOrderId(int customerid, int locationId);
        
    }
}