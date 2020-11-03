using System;
using System.Linq;
using TeaDB;
using TeaDB.Models;
using TeaDB.Entities;
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
        
        private  CustomerService customerService;
        private OrderService orderService;
        private LocationService locationService;

        
        public LocationMenu(int locationId, CustomerModel customer){
            this.customerService = new CustomerService();
            this.orderService = new OrderService();
            this.locationService = new LocationService();

            this.location = locationService.GetLocation(locationId);
            this.customer = customer;
            this.inventory = locationService.GetLocationInventory(locationId);
            
            this.customerService = new CustomerService();
            this.orderService = new OrderService();
            this.locationService = new LocationService();
        }

        public void Start(){
            do{
                Console.WriteLine($"Welcome to our {location.city} Location!");
                System.Console.WriteLine("Available Products are:");
                foreach(var i in inventory){
                    System.Console.WriteLine($"{i.productId} {i.stock}");

                }
                Options();
                int orderid;
                input = System.Console.ReadLine();
                switch(input){
                    case "1":
                        System.Console.WriteLine("Look at past Purchases");
                        List<OrderModel> pastPurchases = customerService.GetOrderHistory(customer);
                        if(pastPurchases == null){
                            System.Console.WriteLine("You have no past purchases");
                        } else {
                            foreach(var p in pastPurchases){
                                List<OrderItemModel> items = orderService.GetOrderItems(p.id);
                                foreach(var i in items){
                                    System.Console.WriteLine($"{locationService.GetLocation(p.id).city} {orderService.GetProduct(i.productId).name} {i.amount}");
                                }
                            }
                         }
                        break;
                    case "2":
                        System.Console.WriteLine("Adding to basket");
                        orderid = orderService.GetOrderId(customer,location.id);
                        if(orderid == -1){
                            NewOrder();
                        } else {
                            OldOrder(orderid);
                        }                        
                        break;
                    case "3":
                        System.Console.WriteLine("ViewingBasket");
                        orderid = orderService.GetOrderId(customer,location.id);
                        if(orderid == -1){
                            System.Console.WriteLine("Basket is empty");
                        } else{
                            BasketMenu basketMenu = new BasketMenu(customer, location.id, orderid);
                            basketMenu.Start();
                        }
                        break;
                    case "4":
                        System.Console.WriteLine("Switching Location");
                        break;

                }
            }while(input!="4");
        }
        

        public void Options(){
            System.Console.WriteLine("[1] Look at your past Purchases");
            System.Console.WriteLine("[2] Add an item to Basket");
            System.Console.WriteLine("[3] look at basket");
            System.Console.WriteLine("[4] switch Location");
        }

        public void NewOrder(){
            
            System.Console.WriteLine("Enter Product id:");
            int productId = Convert.ToInt32(System.Console.ReadLine());
            ProductModel product = orderService.GetProduct(productId);
            System.Console.WriteLine("Enter amount: ");
            int amount = Convert.ToInt32(System.Console.ReadLine());
        
            orderService.NewOrder(customer.id, location.id, (product.price*amount));
            int id = orderService.GetOrderId(customer, location.id);
            orderService.AddProductToOrderList(id, product.id, amount,(product.price*amount));
            InventoryModel inventoryModel = inventory.Where(i => i.productId == product.id && i.locationId == location.id).FirstOrDefault(); 
            orderService.DecreaseStock(inventoryModel, product.id,amount);
            inventory = locationService.GetLocationInventory(location.id);
            
        }

        public void OldOrder(int orderid){
            System.Console.WriteLine(orderid);
            System.Console.WriteLine("Enter Product id:");
            int productId = Convert.ToInt32(System.Console.ReadLine());
            ProductModel product = orderService.GetProduct(productId);
            System.Console.WriteLine("Enter amount: ");
            int amount = Convert.ToInt32(System.Console.ReadLine());
        
            OrderModel order = orderService.GetCurrentOrder(customer.id, location.id);
            orderService.AddProductToOrderList(orderid, product.id, amount,(product.price*amount));
            orderService.ChangeOrderTotalPrice(orderid,  (product.price*amount));
            InventoryModel inventoryModel = inventory.Where(i => i.productId == product.id).FirstOrDefault(); 
            orderService.DecreaseStock(inventoryModel, product.id,amount);
            inventory = locationService.GetLocationInventory(location.id);
        }



        

    }
}