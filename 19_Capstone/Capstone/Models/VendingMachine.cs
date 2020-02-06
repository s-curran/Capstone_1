using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class VendingMachine
    {
        #region Properties
        public List<Product> Products;
        public decimal TotalSales = 0.00M;
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
                    string item = Console.ReadLine();
                    string[] individualItem = item.Split("|");
                    string slot = individualItem[0];
                    string name = individualItem[1];
                    decimal cost = decimal.Parse(individualItem[2]);
                    
                    switch (individualItem[3])
                    {
                        case "Chip":
                            Chip chip = new Chip(slot, name, cost);
                            Products.Add(chip);
                            return;
                        case "Candy":
                            Candy candy = new Candy(slot, name, cost);
                            Products.Add(candy);
                            return;
                        case "Drink":
                            Drink drink = new Drink(slot, name, cost);
                            Products.Add(drink);
                            return;
                        case "Gum":
                            Gum gum = new Gum(slot, name, cost);
                            Products.Add(gum);
                            return;
                    }
                }
            }
        }
        #endregion

        #region Methods
        public void AddMoney(string input)
        {
            decimal num = decimal.Parse(input);
            if (num == 1.00M || num == 2.00m || num == 5.00m || num == 10.00m)
            {
                using (StreamReader st = new StreamReader("Log.txt", true))
                {
                    Console.WriteLine($"{DateTime.Now} FEED MONEY: {CurrentMoneyProvided} {CurrentMoneyProvided + num}");
                }
                CurrentMoneyProvided += num;
            }
            else
            {
                throw new Exception("Please enter $1, $2, $5, or $10");
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
            using (StreamReader st = new StreamReader("Log.txt", true))
            {
                Console.WriteLine($"{DateTime.Now} GIVE CHANGE: {holder} $0.00");
            }
            return $"You have {quarters} quarters, {dimes} dimes, and {nickels} nickels for a total of {holder:C}. Current Money Provided is $0.00.";
            
        }
        #endregion
    }
}
