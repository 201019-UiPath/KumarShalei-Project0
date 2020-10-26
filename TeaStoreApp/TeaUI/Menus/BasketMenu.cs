using System;

namespace TeaUI.Menus
{
    public class BasketMenu
    {
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
                    case "1":
                        System.Console.WriteLine("Modify Amount");
                        break;
                    case "2":
                        System.Console.WriteLine("Place Order");
                        break;
                    case "3":
                        System.Console.WriteLine("Go Back");
                        break;

                }
            }while(input!="3");
        }
        public void Options(){
            System.Console.WriteLine("[0] Delete Item");
            System.Console.WriteLine("[1] Place Order");
            System.Console.WriteLine("[2] Modify Amount");
            System.Console.WriteLine("[3] Leave");
        }
    }
}