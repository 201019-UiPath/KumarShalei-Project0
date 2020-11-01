using TeaDB.Entities;
using TeaDB.IMappers;
using TeaDB.Models;
using TeaDB;
using TeaLib;
using System;
using TeaUI.Menus;

namespace TeaUI.Menus
{

    public class MainMenu
    {
        private string userInput;
        private MainMenu mainMenu;
        private ManagerMenu managerMenu;  
        private TeaContext context;
        private  CustomerService customerService;
        private LocationMenu locationMenu;


       public void Start(){
            string input;
            System.Console.WriteLine("Welcome to *insert name \n Are you a returning Customer? [Y/N]");
            input = System.Console.ReadLine();
            CustomerModel customer = new CustomerModel();
                //get customer info
            if (input.ToLower() == "n"){
                string name;
                System.Console.WriteLine("Enter Name: ");
                name = System.Console.ReadLine();
                customer.name = name;
                customerService.AddCustomer(customer);

            } else{
                customer = customerService.GetCustomer(2);
            }

            if(customer.name == "Manager"){
                ManagerMenu managerMenu = new ManagerMenu();
            } else {
                System.Console.WriteLine("Which location do you want to visit? [1|2|3]");
                input = System.Console.ReadLine();
                LocationMenu locationMenu = new LocationMenu(Convert.ToInt32(input), customer);             
                    
            }
        }
        
    }
}