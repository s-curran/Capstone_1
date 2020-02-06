using Capstone.Models;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                LoadVendingMachine();

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                string input = Console.ReadLine();

            }
        }
        public static void LoadVendingMachine()
        {
            VendingMachine vendingMachine = new VendingMachine("vendingmachine.csv");

        }
    }
}
