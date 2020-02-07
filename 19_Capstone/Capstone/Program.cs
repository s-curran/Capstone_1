using Capstone.Models;
using System;
using System.IO;

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
                Console.Clear();
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        vendingMachine.Display();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        SecondMenu();
                        break;
                    case "3":
                        k = false;
                        break;
                    case "4":
                        vendingMachine.SalesReport();
                        break;
                }
            }
        }
        public static void SecondMenu()
        {
            bool j = true;
            while (j)
            {
                Console.Clear();
                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("");
                Console.WriteLine($"Current Money Provided: ${vendingMachine.Current()}");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter $ amount 1, 2, 5,or 10: ");
                        Console.Write("$");
                        string amount = Console.ReadLine();
                        vendingMachine.AddMoney(amount);
                        break;
                    case "2":
                        Console.Clear();
                        vendingMachine.SelectProduct();
                        string choice = Console.ReadLine().ToUpper();
                        vendingMachine.Choose(choice);
                        break;
                    case "3":
                        Console.Clear();
                        string result = vendingMachine.FinishTransaction();
                        Console.WriteLine(result);
                        Console.ReadLine();
                        j = false;
                        break;
                }
            }
        }
        public static void LoadVendingMachine()
        {
             vendingMachine = new VendingMachine(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\vendingmachine.csv");

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\Log.txt"))
            //{ }



        }
    }
}
