using TeaDB;

using System;

namespace TeaUI.Menus
{
    public class BasketMenu
    {
        private DBRepo Repo;
        public int customerid{get;set;}
        public int locationid{get;set;}
        
        public void Start(){

            string input;
            Console.WriteLine("Your Basket");
            Options();
            
            do{
                input = System.Console.ReadLine();
                switch(input){
                    case "0":
                        System.Console.WriteLine("DeleteItem");

                        break;
                    // case "1":
                    //     System.Console.WriteLine("Modify Amount");
                    //     break;
                    case "1":
                        System.Console.WriteLine("Place Order");
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