using TeaDB.Models;

namespace TeaDB.IRepo
{
    public interface IOrderListRepo
    {
        void AddProductToOrderList(OrderListModel order);
        void DeleteProductFromOrderList(OrderListModel order);
    }
}