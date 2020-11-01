using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    //public delegate void InventoryDel();

    public class InventoryService
    {
        //public event InventoryDel outOfStock;
        private IInventoryRepo repo;
        public InventoryService(IInventoryRepo repo){
            this.repo = repo;
        }

        public void ReplenishStock(int locationid, int productid, int amount){
            repo.ReplenishStock(locationid,productid,amount);
        }

    }
}