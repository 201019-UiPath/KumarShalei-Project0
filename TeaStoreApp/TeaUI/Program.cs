using System;
using TeaLib;
using TeaDB;
using TeaDB.Entities;
using TeaDB.Models;
using TeaDB.IMappers;
using TeaUI.Menus;

namespace TeaUI
{
    class Program
    {

        static void Main(string[] args)
        {
            MainMenu start = new MainMenu();
            start.Start();
        }    
    }
}
