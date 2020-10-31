using TeaDB.Models;
using TeaDB.Entities;
using System.Collections.Generic;

namespace TeaDB
{
    public interface IOrderListMapper
    {
        Orderlist ParseOrderList(OrderListModel orderList);
        ICollection<Orderlist> ParseProduct(List<OrderListModel> orderList);
        OrderListModel ParseProduct(Orderlist orderlist);
        List<OrderListModel> ParseProduct(ICollection<Orderlist> orderlist);
    }
}
