using TeaDB.Models;
using TeaDB.Entities;
using System.Collections.Generic;

namespace TeaDB.IMappers
{
    public interface IOrderItemMapper
    {
        Orderitems ParseOrderItem(OrderItemModel orderItem);
        ICollection<Orderitems> ParseOrderItem(List<OrderItemModel> orderItem);
        OrderItemModel ParseOrderItem(Orderitems orderitems);
        List<OrderItemModel> ParseOrderItem(ICollection<Orderitems> orderitems);
    }
}
