using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.Entities;
using TeaLib;
//using TeaDB;
using System.Collections.Generic;
namespace TeaUI.Menus
{
    public class LocationMenu
    {
        private int locationId;
        private CustomerModel customer;
        private  CustomerService customerService;
        private ProductService productService;
        private OrderListService  orderlistService;
        private OrderService orderService;
        private LocationService locationService;

        
        public LocationMenu(int locationId,CustomerModel customer){
            this.locationId = locationId;
            this.customer = customer;
            this.customerService = new CustomerService();
            this.productService = new ProductService();
            this.orderlistService = new OrderListService();
            this.locationService = new LocationService();
            
        }

        public void Start(){
            string input;
            Console.WriteLine($"Welcome to our Location {this.locationId}!");
            Options();
            
            do{
                input = System.Console.ReadLine();
                switch(input){
                    case "0":
                        System.Console.WriteLine("Look at Products");
                        List<InventoryModel> products = locationService.GetLocationInventory(locationId);
                        foreach(var p in products){
                            System.Console.WriteLine($"{p.productId} {p.stock}");
                        }
                        break;
                    case "1":
                        System.Console.WriteLine("Look at past Purchases");
                        List<OrderModel> pastPurchases = customerService.GetOrderHistory(customer.id);
                            foreach(var p in pastPurchases){
                                System.Console.WriteLine($"{p.id}");
                            }
                        break;
                    case "2":
                        System.Console.WriteLine("Adding to basket");
                        if(!orderService.OldOrder(this.customer.id,locationId)){
                            
                            orderService.NewOrder(this.customer.id,locationId);
                        }
                        int orderid = orderService.GetOrderId(this.customer.id,locationId);
                        System.Console.WriteLine("Which Product?");
                        int productId = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("How many?");
                        int amount = Convert.ToInt32(System.Console.ReadLine());
                        orderlistService.AddProductToOrderList(new OrderListModel(){
                            orderId = orderid,
                            productId = productId,
                            amount= amount});
                        
                        break;
                    case "3":
                        System.Console.WriteLine("ViewingBasket");
                        if(!orderService.OldOrder(customer.id,locationId)){
                            System.Console.WriteLine("Basket is empty");
                        } else{
                            int x = orderService.GetOrderId(customer.id,locationId);
                            List<OrderListModel> items = orderlistService.GetItemsInBasket(x);
                            BasketMenu basketMenu = new BasketMenu(items);
                            basketMenu.customerid = customer.id;
                            basketMenu.locationid = locationId;
                            basketMenu.orderid = x;

                            basketMenu.Start();
                        }
                        break;
                    case "4":
                        System.Console.WriteLine("Switching Location");
                        break;
                    case "5":
                        System.Console.WriteLine("Bye");
                        break;

                }
            }while(input!="4" || input !="5");
        }
        

        public void Options(){
            System.Console.WriteLine("[0] Look at Products");
            System.Console.WriteLine("[1] Look at your past Purchases");
            System.Console.WriteLine("[2] Add an item to Basket");
            System.Console.WriteLine("[3] look at basket");
            System.Console.WriteLine("[4] switch Location");
            System.Console.WriteLine("[5] Leave");
        }

    }
}