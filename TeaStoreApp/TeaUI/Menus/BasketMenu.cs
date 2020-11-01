using TeaDB;
using System.Collections.Generic;
using System;
using TeaDB.Models;
using TeaLib;




namespace TeaUI.Menus
{
    public class BasketMenu
    {
        private  CustomerService customerService;
        private ProductService productService;
        private OrderListService  orderlistService;
        private OrderService orderService;
        private LocationService locationService;
        public int customerid{get;set;}
        public int locationid{get;set;}
        public int orderid{get;set;}

        private List<OrderListModel> products;

        
        public BasketMenu(List<OrderListModel> products){
            this.products = products;
            this.customerService = new CustomerService();
            this.productService = new ProductService();
            this.orderlistService = new OrderListService();
            this.orderService = new OrderService();
            this.locationService = new LocationService();
        }

        public void Start(){

            
            string input;
            Console.WriteLine("Your Basket");
            Options();
            
            do{
                input = System.Console.ReadLine();
                switch(input){
                    case "0":
                        System.Console.WriteLine("Enter Item to delete");
                        int productid = Convert.ToInt32(System.Console.ReadLine());
                        orderlistService.DeleteProductFromOrderList(productid,orderid);
                        if(products == null){
                            orderService.DeleteOrder(orderid);
                        }
                        break;
                    case "1":
                        System.Console.WriteLine("Place Order");
                        orderService.PlaceOrder(orderid);
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        break;

                }
            }while(input!="2");
        }
        public void Options(){
            System.Console.WriteLine("[0] Place Order");
            System.Console.WriteLine("[1] Delete Item");
            //System.Console.WriteLine("[2] Modify Amount");
            System.Console.WriteLine("[2] Go Back");
        }

        public void DeleteItem(){
            string userInput;
            System.Console.WriteLine("Which Product ID would you like to remove from your Basket?");
            userInput = System.Console.ReadLine();


        }
    }
}