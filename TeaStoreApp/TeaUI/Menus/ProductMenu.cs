using System;
namespace TeaUI.Menus
{
    public class ProductMenu
    {
        public void Start(){

            string input;
            Console.WriteLine("Items");
            Options();
            
            do{
                input = System.Console.ReadLine();
                switch(input){
                    case "0":
                        System.Console.WriteLine("Adding to basket");
                        break;
                    case "1":
                        System.Console.WriteLine("View Basket");
                        break;
                    case "2":
                        System.Console.WriteLine("Go Back");
                        break;
                    case "3":
                        System.Console.WriteLine("Fun Fact");
                        break;

                }
            }while(input!="2");
        }

        public void Options(){
            System.Console.WriteLine("[0] Add to Basket");
            System.Console.WriteLine("[1] View Basket");
            System.Console.WriteLine("[2] Go Back");
            System.Console.WriteLine("[2] Fun Fact");
        }
    }
}