using Capstone.Models;
using System;

namespace Capstone
{
    class Program
    {
        public static VendingMachine vendingMachine;
        static void Main(string[] args)
        {
            bool k = true;
            while (k)
            {
                LoadVendingMachine();

                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        vendingMachine.Display();
                        break;
                    case "2":
                        break;
                    case "3":
                        k = false;
                        break;
                       
                    case "4":
                        Console.WriteLine("eat pant");
                        break;
                }
            }
        }
        public static void LoadVendingMachine()
        {
             vendingMachine = new VendingMachine(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\vendingmachine.csv");

        }
    }
}
