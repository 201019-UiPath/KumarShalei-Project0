using System.Collections.Generic;
using TeaDB.Models;
using System.Threading.Tasks;

namespace TeaDB.IRepo
{
    public interface ILocationRepo
    {
        LocationModel GetLocation(int id);
        List<OrderModel> GetLocationOrderHistory(int id);
        List<InventoryModel> GetLocationInventory(int id);
        // ProductModel GetProductInfo(int id);

    }
}