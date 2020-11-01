using TeaDB.Models;
using System.Collections.Generic;
namespace TeaDB.IRepo
{
    public interface IOrderListRepo
    {
        void AddProductToOrderList(OrderListModel order);
        void DeleteProductFromOrderList(OrderListModel order);
        List<OrderListModel> GetItemsInBasket(int orderid);
    }
}