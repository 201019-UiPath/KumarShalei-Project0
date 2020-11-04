using System;
using TeaDB.Models;
using TeaLib;
using System.Collections.Generic;

namespace TeaUI.Menus
{
    public class ManagerMenu
    {

        private LocationService locationService;
        private ManagerService managerService;
        private OrderService orderService;

        public ManagerMenu(){
            this.locationService = new LocationService();
            this.managerService = new ManagerService();
            this.orderService = new OrderService();
        }

        public void Start(){

            System.Console.WriteLine("Welcome Back Ma'am");
            int input;
            do{
                System.Console.WriteLine("Which store Inventory would you like to view? [1|2|3] \n Press 0 to exit");
                input = Convert.ToInt32(System.Console.ReadLine());
                List<InventoryModel> invetory = locationService.GetLocationInventory(input);
                foreach(var i in invetory){
                    System.Console.WriteLine($"{i.productId} {i.stock}");
                }
                System.Console.WriteLine("Would you like to restock? [Y/N]" );
                string restock = System.Console.ReadLine();
                if(restock.ToLower() == "y"){
                    System.Console.WriteLine("Enter Product id");
                    int productid = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("Enter amount: ");
                    int amount = Convert.ToInt32(System.Console.ReadLine());
                    managerService.ReplenishStock(input, productid, amount);

                }

                System.Console.WriteLine("Would you like to look at order History? [Y/N]" );
                string orderHistory = System.Console.ReadLine();
                if(orderHistory.ToLower() =="y"){
                    
                    List<OrderModel> pastPurchases;
                    System.Console.WriteLine("Would you like to sort: \n [1] Least to Most Expensive \n [2] Most to least Expensive \n Enter Number [1/2]:");
                    string orderBy = System.Console.ReadLine();
                    if(orderBy == "1"){
                        pastPurchases = managerService.GetOrderHistoryLocationByMostExpensive(input);
                    } else {
                        pastPurchases = managerService.GetOrderHistoryLocationByLeastExpensive(input);
                    }

                    if(pastPurchases == null){
                            System.Console.WriteLine("You have no past purchases");
                        } else {
                            foreach(var p in pastPurchases){
                                List<OrderItemModel> items = orderService.GetOrderItems(p.id);
                                foreach(var i in items){
                                    System.Console.WriteLine($"{locationService.GetLocation(p.locationId).city } {orderService.GetProduct(i.productId).name} {i.amount}");
                                }
                            }
                         }

                }
            } while(input != 0);

        }
    }
}