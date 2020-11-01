using TeaDB.Entities;
using TeaDB.IMappers;
using TeaDB;
using TeaLib;
using System;

namespace TeaUI.Menus
{
    public class MainMenu
    {
        private string userInput;
        private LocationMenu locationMenu;  


        public MainMenu(TeaContext context, IMapper mapper){
            //this.locationMenu = new LocationMenu(new DBRepo(context,mapper), new OrderPlaced());
            //this.mapper = mapper;
            
        }

        void Start(){
            string input;
            System.Console.WriteLine("Welcome to *insert name \n Are you a returning Customer? [Y/N]");
            input = System.Console.ReadLine();
            if (input.ToLower() == "y"){
                //get customer info
            } else {
                string name;
                System.Console.WriteLine("Enter Name: ");
                name = System.Console.ReadLine();
                //new customer
            }

            System.Console.WriteLine("Which Location would you like to visit?");
            input = System.Console.ReadLine();

            //Call location menu

        }
    }
}