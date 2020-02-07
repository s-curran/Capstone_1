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
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine(@" __ __    ___  ____   ___    ____  ____    ____      ___ ___   ____     __  __ __  ____  ____     ___ ");
                Console.WriteLine(@"|  |  |  /  _]|    \ |   \  |    ||    \  /    |    |   |   | /    |   /  ]|  |  ||    ||    \   /  _]");
                Console.WriteLine(@"|  |  | /  [_ |  _  ||    \  |  | |  _  ||   __|    | _   _ ||  o  |  /  / |  |  | |  | |  _  | /  [_ ");
                Console.WriteLine(@"|  |  ||    _]|  |  ||  D  | |  | |  |  ||  |  |    |  \_/  ||     | /  /  |  _  | |  | |  |  ||    _]");
                Console.WriteLine(@"|  :  ||   [_ |  |  ||     | |  | |  |  ||  |_ |    |   |   ||  _  |/   \_ |  |  | |  | |  |  ||   [_ ");
                Console.WriteLine(@" \   / |     ||  |  ||     | |  | |  |  ||     |    |   |   ||  |  |\     ||  |  | |  | |  |  ||     |");
                Console.WriteLine(@"  \_/  |_____||__|__||_____||____||__|__||___,_|    |___|___||__|__| \____||__|__||____||__|__||_____|");
                Console.WriteLine();
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine();
                Console.WriteLine("2) Purchase");
                Console.WriteLine();
                Console.WriteLine("3) Exit");
                Console.WriteLine();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(@"
______              _            _       
| ___ \            | |          | |      
| |_/ / __ ___   __| |_   _  ___| |_ ___ 
|  __/ '__/ _ \ / _` | | | |/ __| __/ __|
| |  | | | (_) | (_| | |_| | (__| |_\__ \
\_|  |_|  \___/ \__,_|\__,_|\___|\__|___/
                                         
                                         ");
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
                Console.WriteLine(@"
______ _   ___   __
| ___ \ | | \ \ / /
| |_/ / | | |\ V / 
| ___ \ | | | \ /  
| |_/ / |_| | | |  
\____/ \___/  \_/  
                   
                   ");
                Console.WriteLine();
                Console.WriteLine("1) Feed Money");
                Console.WriteLine();
                Console.WriteLine("2) Select Product");
                Console.WriteLine();
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("");
                Console.WriteLine($"Current Money Provided: ${vendingMachine.Current()}");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(@"       
    /$$      /$$      /$$   
  /$$$$$$  /$$$$$$  /$$$$$$ 
 /$$__  $$/$$__  $$/$$__  $$
| $$  \__/ $$  \__/ $$  \__/
|  $$$$$$|  $$$$$$|  $$$$$$ 
 \____  $$\____  $$\____  $$
 /$$  \ $$/$$  \ $$/$$  \ $$
|  $$$$$$/  $$$$$$/  $$$$$$/
 \_  $$_/ \_  $$_/ \_  $$_/ 
   \__/     \__/     \__/   
                            ");
                        Console.WriteLine("Enter $ amount 1, 2, 5,or 10: ");
                        Console.Write("$");
                        string amount = Console.ReadLine();
                        vendingMachine.AddMoney(amount);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(@"
______              _            _       
| ___ \            | |          | |      
| |_/ / __ ___   __| |_   _  ___| |_ ___ 
|  __/ '__/ _ \ / _` | | | |/ __| __/ __|
| |  | | | (_) | (_| | |_| | (__| |_\__ \
\_|  |_|  \___/ \__,_|\__,_|\___|\__|___/
                                         
                                         ");
                        vendingMachine.SelectProduct();
                        string choice = Console.ReadLine().ToUpper();
                        vendingMachine.Choose(choice);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(@"       
    /$$      /$$      /$$   
  /$$$$$$  /$$$$$$  /$$$$$$ 
 /$$__  $$/$$__  $$/$$__  $$
| $$  \__/ $$  \__/ $$  \__/
|  $$$$$$|  $$$$$$|  $$$$$$ 
 \____  $$\____  $$\____  $$
 /$$  \ $$/$$  \ $$/$$  \ $$
|  $$$$$$/  $$$$$$/  $$$$$$/
 \_  $$_/ \_  $$_/ \_  $$_/ 
   \__/     \__/     \__/   
                            ");
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
