using TeaDB.Models;
using System.Collections.Generic;
namespace TeaDB.IRepo
{
    public interface IOrderListRepo
    {
        void AddProductToOrderList(OrderListModel order);
        void DeleteProductFromOrderList(int orderid, int productid);
        List<OrderListModel> GetItemsInBasket(int orderid);
    }
}