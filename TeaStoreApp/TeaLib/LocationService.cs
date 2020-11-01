using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class LocationService
    {
        private ILocationRepo repo;

        public LocationService(ILocationRepo repo){
            this.repo = repo;
        }

        public List<OrderModel> GetLocationOrderHistory(int x){
            return repo.GetLocationOrderHistory(x);
        }
        public List<InventoryModel> GetLocationInventory(int x){
            return repo.GetLocationInventory(x);
        }
    }
}