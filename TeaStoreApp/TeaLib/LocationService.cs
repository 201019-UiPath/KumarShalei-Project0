using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class LocationService
    {
        private DBRepo repo;

        public LocationService(){
            this.repo = new DBRepo();
        }

        public List<OrderModel> GetLocationOrderHistory(int x){
            return repo.GetLocationOrderHistory(x);
        }
        public List<InventoryModel> GetLocationInventory(int x){
            return repo.GetLocationInventory(x);
        }

        public LocationModel GetLocation(int id){
            return repo.GetLocation(id);
        }

    }
}