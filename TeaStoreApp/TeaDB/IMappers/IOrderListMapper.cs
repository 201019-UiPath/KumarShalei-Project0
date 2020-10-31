using TeaDB.Models;
using TeaDB.Entities;
using System.Collections.Generic;

namespace TeaDB
{
    public interface IOrderListMapper
    {
        Orderlist ParseOrderList(OrderListModel orderList);
        ICollection<Orderlist> ParseOrderList(List<OrderListModel> orderList);
        OrderListModel ParseOrderList(Orderlist orderlist);
        List<OrderListModel> ParseOrderList(ICollection<Orderlist> orderlist);
    }
}
