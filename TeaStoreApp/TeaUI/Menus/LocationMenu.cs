using System;
using System.Linq;
using TeaDB.Models;
using TeaLib;
using System.Collections.Generic;
namespace TeaUI.Menus
{
    public class LocationMenu
    {
        private string input;
        private LocationModel location;
        private CustomerModel customer;
        private List<InventoryModel> inventory;
        
        private MainMenuService mainMenuService;
        private OrderService orderService;
        private LocationService locationService;

        
        public LocationMenu(int locationId, CustomerModel customer){
            this.mainMenuService = new MainMenuService();
            this.orderService = new OrderService();
            this.locationService = new LocationService();

            this.location = locationService.GetLocation(locationId);
            this.customer = customer;
            // this.inventory = locationService.GetLocationInventory(locationId);
        }

        public void Start(){
            do{
                Console.WriteLine($"Welcome to our {location.city} Location!");
                
                Options();
                int orderid;
                string sortByCost = @"[YyNn]";
                string orderBy = @"[12]";
                input = System.Console.ReadLine();
                
                switch(input){
                    case "1":
                        System.Console.WriteLine("Available Products are:");
                        System.Console.WriteLine("[ProductID]  [Product Name] [Stock]");
                        inventory = locationService.GetLocationInventory(location.id);
                        foreach(var i in inventory){
                            System.Console.WriteLine($"{i.productId} {orderService.GetProduct(i.productId).name}   {i.stock}");

                        }
                        break;
                    case "2":
                        System.Console.WriteLine("Look at past Purchases");
                        System.Console.WriteLine("Would you like to sort by cost? [Y/N]");
                        sortByCost = System.Console.ReadLine();
                        List<OrderModel> pastPurchases;
                        if(sortByCost.ToLower() == "y"){
                            System.Console.WriteLine("Would you like to sort: \n [1] Least to Most Expensive \n [2] Most to least Expensive \n Enter Number [1/2]:");
                            orderBy = System.Console.ReadLine();
                            if(orderBy == "1"){
                                pastPurchases = mainMenuService.GetOrderHistoryByMostExpensive(customer);
                            } else {
                                pastPurchases = mainMenuService.GetOrderHistoryByLeastExpensive(customer);
                            }
                            
                        } else {
                            pastPurchases = mainMenuService.GetOrderHistory(customer);
                        }

                        
                        if(pastPurchases == null){
                            System.Console.WriteLine("You have no past purchases");
                        } else {
                            foreach(var p in pastPurchases){
                                List<OrderItemModel> items = orderService.GetOrderItems(p.id);
                                foreach(var i in items){
                                    System.Console.WriteLine($"{location.city} {orderService.GetProduct(i.productId).name} {i.amount}");
                                }
                            }
                         }
                        break;
                    case "3":
                        System.Console.WriteLine("Adding to basket");
                        orderid = orderService.GetOrderId(customer,location.id);
                        if(orderid == -1){
                            NewOrder();
                        } else {
                            OldOrder(orderid);
                        }                        
                        break;
                    case "4":
                        System.Console.WriteLine("ViewingBasket");
                        orderid = orderService.GetOrderId(customer,location.id);
                        if(orderid == -1){
                            System.Console.WriteLine("Basket is empty");
                        } else{
                            BasketMenu basketMenu = new BasketMenu(customer, location.id, orderid);
                            basketMenu.Start();
                        }
                        break;
                    case "5":
                        System.Console.WriteLine("Switching Location");
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid input");
                        break;

                }
            }while(input!="5");
        }
        

        public void Options(){
            System.Console.WriteLine("[1] Look at Products");
            System.Console.WriteLine("[2] Look at your past Purchases");
            System.Console.WriteLine("[3] Add an item to Basket");
            System.Console.WriteLine("[4] look at basket");
            System.Console.WriteLine("[5] switch Location");
        }

        public void NewOrder(){
            
            System.Console.WriteLine("Enter Product id:");
            int productId = Convert.ToInt32(System.Console.ReadLine());
            ProductModel product = orderService.GetProduct(productId);
            System.Console.WriteLine("Enter amount: ");
            int amount = Convert.ToInt32(System.Console.ReadLine());
        
            orderService.NewOrder(customer.id, location.id, (product.price*amount));
            int id = orderService.GetOrderId(customer, location.id);
            orderService.AddProductToOrderItem(id, product.id, amount,(product.price*amount));
        
            orderService.DecreaseStock(location.id, product.id,amount);
            
            
        }

        public void OldOrder(int orderid){
            System.Console.WriteLine(orderid);
            System.Console.WriteLine("Enter Product id:");
            int productId = Convert.ToInt32(System.Console.ReadLine());
            ProductModel product = orderService.GetProduct(productId);
            System.Console.WriteLine("Enter amount: ");
            int amount = Convert.ToInt32(System.Console.ReadLine());
        
            OrderModel order = orderService.GetCurrentOrder(customer.id, location.id);
            orderService.AddProductToOrderItem(orderid, product.id, amount,(product.price*amount));
            orderService.ChangeOrderTotalPrice(orderid,  (product.price*amount));
            orderService.DecreaseStock(location.id, product.id,amount);
            
        }

    }
}