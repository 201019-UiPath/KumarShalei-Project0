using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.Entities;
namespace TeaUI.Menus
{
    public class LocationMenu
    {
        private int locationId;
        public LocationMenu(int locationId,CustomerModel customer){
            this.locationId = locationId;
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
                        break;
                    case "1":
                        System.Console.WriteLine("Look at past Purchases");
                        break;
                    case "2":
                        System.Console.WriteLine("ViewingBasket");
                        break;
                    case "3":
                        System.Console.WriteLine("Switching Location");
                        break;
                    case "4":
                        System.Console.WriteLine("Bye");
                        break;

                }
            }while(input!="4");
        }
        

        public void Options(){
            System.Console.WriteLine("[0] Look at Products");
            System.Console.WriteLine("[1] Look at your past Purchases");
            System.Console.WriteLine("[2] Add an item to Basket");
            System.Console.WriteLine("[3] Switch Locations");
            System.Console.WriteLine("[4] Leave");
        }

        public void ProductList(){

        }
    }
}