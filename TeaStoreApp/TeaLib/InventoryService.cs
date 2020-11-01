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

        private DBRepo repo;
        public InventoryService(){
            this.repo = new DBRepo();
        }

        public void ReplenishStock(int locationid, int productid, int amount){
            repo.ReplenishStock(locationid,productid,amount);
        }

    }
}