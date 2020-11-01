using System;
using TeaLib;
using TeaDB;
using TeaUI.Menus;

namespace TeaUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            LocationMenu startMenu = new LocationMenu(x);
            startMenu.Start();


        }

        

    }
}
