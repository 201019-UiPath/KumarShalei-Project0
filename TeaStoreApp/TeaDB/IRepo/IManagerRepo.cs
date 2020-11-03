using TeaDB.Models;
namespace TeaDB.IRepo
{
    public interface IManagerRepo
    {
         void ReplenishStock(InventoryModel inventory, int amount);
         
    }
}