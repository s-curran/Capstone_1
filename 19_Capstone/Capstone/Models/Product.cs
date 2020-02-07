using Capstone.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public abstract class Product 
    {
        #region Properties
        public string Slot { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Quantity { get; private set; } 
        public string Message { get; set; }
       
        #endregion

        #region Constructor
        public Product(string slot, string name, decimal cost)
        {
            this.Slot = slot;
            this.Name = name;
            this.Cost = cost;
            this.Quantity = "5";
        }
        #endregion

        #region Methods
        

        public void Subtract()
        {
            if (this.Quantity == "SOLD OUT!")
            {
                throw new OutOfStockException();
            }
            int num = int.Parse(this.Quantity);
            if (num > 0)
            {
                num -= 1;
                if (num == 0)
                {
                    this.Quantity = "SOLD OUT!";
                }
                else
                {
                    this.Quantity = $"{num}";
                }
            }
        }

        public decimal Purchase(Product product, decimal CMP)
        {
             if (product.Cost > CMP)
             {
                 throw new InsufficientFundsException("Not enough money!");
             }
             else
             {
                 product.Subtract();
                 Console.WriteLine($"{"Product", -20}{"Cost", -10} {"Money Remaining", -10}");
                 Console.WriteLine($"{product.Name, -20}${product.Cost, -10}${CMP - product.Cost, -10}\n{product.Message}");
                 using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-7\19_Capstone\Log.txt", true))
                 {
                     sw.WriteLine($"{DateTime.Now} {product.Name} {CMP:C} {CMP - product.Cost:C}");
                 }
                 CMP -= product.Cost;
             }
            return CMP;
        }

        #endregion

    }
}
