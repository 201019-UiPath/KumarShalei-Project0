using System;
using TeaDB.Models;
using TeaLib;
using System.Collections.Generic;

namespace TeaUI.Menus
{
    public class ManagerMenu
    {

        private LocationService locationService;

        public ManagerMenu(){
            locationService = new LocationService();
        }

        public void Start(){

            System.Console.WriteLine("Welcome Back Ma'am");
            int input;
            do{
                System.Console.WriteLine("Which store Inventory would you like to view? [1|2|3]");
                input = Convert.ToInt32(System.Console.ReadLine());
                List<InventoryModel> invetory = locationService.GetLocationInventory(input);
                foreach(var i in invetory){
                    System.Console.WriteLine($"{i.productId} {i.stock}");
                }
                

            } while(input != 0);
        }
    }
}