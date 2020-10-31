using TeaDB.Entities;
using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB
{
    public interface IInventoryMapper
    {
        Inventory ParseInventory(InventoryModel inventory);
        ICollection<Inventory> ParseInventory(List<InventoryModel> inventory);
        InventoryModel ParseInventory(Inventory inventorys);
        List<InventoryModel> ParseInventory(ICollection<Inventory> inventorys);
    }
}