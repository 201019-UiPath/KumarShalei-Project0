using System;
using TeaLib;
using TeaDB;
using TeaDB.Entities;
using TeaDB.Models;
using TeaDB.IMappers;
using TeaUI.Menus;
using Serilog;

namespace TeaUI
{
    class Program
    {

        static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("loggingfile.txt")
            .CreateLogger();

            MainMenu start = new MainMenu();
            start.Start();
        }    
    }
}
