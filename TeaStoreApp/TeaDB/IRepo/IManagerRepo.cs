using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB.IRepo
{
    public interface IManagerRepo
    {
         void ReplenishStock(int locationid, int productid, int amount);
        List<OrderModel> GetOrderHistoryLocationByMostExpensive(int locationid);
        List<OrderModel> GetOrderHistoryLocationByLeastExpensive(int locationid);
        List<OrderModel> GetLocationOrderHistory(int id);
         
    }
}