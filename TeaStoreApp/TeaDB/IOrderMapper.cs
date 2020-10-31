using TeaDB.Entities;
using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB
{
    public interface IOrderMapper
    {
        Orders ParseOrder(OrderModel order);
        ICollection<Orders> ParseOrder(List<OrderModel> order);
        OrderModel ParseOrder(Orders orders);
        List<OrderModel> ParseOrder(ICollection<Orders> orders);
    }
}