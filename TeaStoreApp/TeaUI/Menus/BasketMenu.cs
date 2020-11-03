using TeaDB;
using System.Collections.Generic;
using System;
using TeaDB.Models;
using TeaLib;
using System.Linq;



namespace TeaUI.Menus
{
    public class BasketMenu
    {
        private  CustomerService customerService;

        private OrderService orderService;
        private LocationService locationService;
        public CustomerModel customer;
        public int locationid;
        public int orderid;

        private List<OrderItemModel> products;

        
        public BasketMenu(CustomerModel customer, int locationid, int orderid){
            this.locationService  = new LocationService();
            this.orderService = new OrderService();
            this.customerService = new CustomerService();

            this.customer = customer;
            this.locationid = locationid;
            this.orderid = orderid;
            this.products = orderService.GetItemsInBasket(orderid);
        }

        public void Start(){

            
            string input;
            Console.WriteLine("Your Basket");
            foreach(var p in products){
                System.Console.WriteLine($"{orderService.GetProduct(p.productId).name} {p.amount}");
            }
            
            
            do{
                Options();
                input = System.Console.ReadLine();
                
                switch(input){
                    case "0":
                        DeleteItem();
                        break;
                    case "1":
                        System.Console.WriteLine("Place Order");
                        OrderModel order = orderService.GetCurrentOrder(customer.id, locationid);
                        orderService.PlaceOrder(order);
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        break;

                }
            }while(input!="2");
        }
        public void Options(){
            System.Console.WriteLine("[0] Delete Item");
            System.Console.WriteLine("[1] Place Order");
            System.Console.WriteLine("[2] Go Back");
        }

        public void DeleteItem(){
            
            System.Console.WriteLine("Which Product ID would you like to remove from your Basket?");
            int id = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine();
            OrderItemModel item = products.First(o => o.productId == id);
            products.Remove(item);
            orderService.DeleteProductFromOrderItem(orderid, id);
            decimal dec = (item.totalPrice) * (-1);
            
            if(products == null){
                System.Console.WriteLine("Basket is Empty");
                orderService.DeleteOrder(orderid);
            } else {
                orderService.ChangeOrderTotalPrice(orderid, dec);
            }
            
        }
    }
}