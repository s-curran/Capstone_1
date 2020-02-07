using Capstone.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Capstone.Models
{
    public class VendingMachine
    {
        #region Properties
        public static List<Product> Products;
        public static Dictionary<string, int> Sold = new Dictionary<string, int>();
        public static decimal TotalSales = 0.00M;
        decimal CurrentMoneyProvided = 0.00M;
        #endregion

        #region Constructor
        public VendingMachine(string path)
        {
            Products = new List<Product>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string item = sr.ReadLine();
                    string[] individualItem = item.Split("|");
                    string slot = individualItem[0];
                    string name = individualItem[1];
                    decimal cost = decimal.Parse(individualItem[2]);
                    
                    switch (individualItem[3])
                    {
                        case "Chip":
                            Chip chip = new Chip(slot, name, cost);
                            Products.Add(chip);
                            break;
                        case "Candy":
                            Candy candy = new Candy(slot, name, cost);
                            Products.Add(candy);
                            break;
                        case "Drink":
                            Drink drink = new Drink(slot, name, cost);
                            Products.Add(drink);
                            break;
                        case "Gum":
                            Gum gum = new Gum(slot, name, cost);
                            Products.Add(gum);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Methods
        public decimal Current()
        {
            return CurrentMoneyProvided;
        }
        public void Choose(string choice)
        {
            foreach (Product item in Products)
            {
                try
                {
                    if (choice == item.Slot)
                    {
                        Console.Clear();
                        CurrentMoneyProvided = item.Purchase(item, CurrentMoneyProvided);
                        TotalSales += item.Cost;
                        if (Sold.ContainsKey(item.Name))
                        {
                            Sold[item.Name] += 1;
                        }
                        else
                        {
                            Sold[item.Name] = 1;
                        }
                        Thread.Sleep(3000);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Product does not exist.");
                        Thread.Sleep(2000);
                        break;
                    }
                }
                catch (InsufficientFundsException)
                {
                    Console.WriteLine($"Please add more money!");
                    Thread.Sleep(2000);
                }
                catch (OutOfStockException)
                {
                    Console.WriteLine("Product Out of Stock");
                    Thread.Sleep(2000);
                }
                if (choice == "")
                {
                    break;
                }
            }
        }
        public void AddMoney(string input)
        {
            decimal num = 0M;
            if (input == "")
            {
                return;
            }
            else
            {
                num = decimal.Parse(input);
            }
            if (num == 1.00M || num == 2.00m || num == 5.00m || num == 10.00m)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\Log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY: {CurrentMoneyProvided:C} {CurrentMoneyProvided + num:C}");
                }
                CurrentMoneyProvided += num;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter $1, $2, $5, or $10");
                Thread.Sleep(2000);
            }
        }
        public string FinishTransaction()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            decimal holder = CurrentMoneyProvided;
            while (CurrentMoneyProvided >= 0.25M)
            {
                CurrentMoneyProvided -= 0.25M;
                quarters++;
            }
            while (CurrentMoneyProvided >= 0.10M)
            {
                CurrentMoneyProvided -= 0.10M;
                dimes++;
            }
            while (CurrentMoneyProvided >= 0.05M)
            {
                CurrentMoneyProvided -= 0.05M;
                nickels++;
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\Log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {holder:C} $0.00");
            }
            return $"You have {quarters} quarters, {dimes} dimes, and {nickels} nickels for a total of {holder:C} in change. \nCurrent Money Provided is $0.00.";
        }
        public void SelectProduct()
        {
            Console.WriteLine($"{"Current Money Provided: "}{CurrentMoneyProvided:C}");
            Console.WriteLine();
            Console.WriteLine($"{"Slot", -5}{"Name", -20}{"Cost", -10}{"Quantity", -20}");
            Console.WriteLine();
            foreach (Product item in Products)
            {
                Console.WriteLine($"{item.Slot, -5}{item.Name, -20}{item.Cost, -10:C}{item.Quantity, -10}");
                

            }
        }
        public void SalesReport()
        {
            using (StreamWriter sw = new StreamWriter($@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\SalesReport{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-tt")}.txt", true))
            {
                foreach (KeyValuePair<string, int> kvp in Sold)
                {
                    sw.WriteLine($"{kvp.Key}|{kvp.Value}");
                }
                sw.WriteLine();
                sw.WriteLine($"Total Sales: {TotalSales:C}");
            }
            Console.WriteLine("Sales Report created.");
            Thread.Sleep(2000);
        }
       
        #endregion
    }
}
