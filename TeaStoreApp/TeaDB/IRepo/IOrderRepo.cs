using TeaDB.Entities;
using TeaDB.Models;

namespace TeaDB.IRepo
{
    public interface IOrderRepo
    {
        void NewOrder(OrderModel order);
        void OldOrder(OrderModel order);
        void DeleteOrder(OrderModel order);
        
    }
}