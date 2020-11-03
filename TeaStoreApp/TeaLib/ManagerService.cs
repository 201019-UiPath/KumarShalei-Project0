using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    //public delegate void InventoryDel();

    public class ManagerService
    {

        private DBRepo repo;
        public ManagerService(){
            this.repo = new DBRepo();
        }

        public void ReplenishStock(int locationid, int productid, int stock, int amount){
            InventoryModel inventory = new InventoryModel(){
                locationId = locationid,
                productId = productid,
                stock = stock
            };
            repo.ReplenishStock(inventory,amount);
        }

    }
}