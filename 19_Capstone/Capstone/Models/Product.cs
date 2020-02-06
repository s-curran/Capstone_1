using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    abstract class Product : IPurchaseable
    {
        #region Properties
        public string Slot { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        protected string Quantity { get; private set; }
        public string Message { get; set; }
        //protected decimal Revenue { get; private set; } = 0.00M;
        public Dictionary<string, int> Sold { get; private set; }
       
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
            int num = int.Parse(this.Quantity);
            if (num > 0)
            {
                num -= 1;
                if (this.Quantity == "0")
                {
                    this.Quantity = "SOLD OUT!";
                }
                else
                {
                    this.Quantity = $"{num}";
                }
            }
        }

        public decimal Purchase(string slot, List<Product> products, decimal CMP)
        {
            foreach (Product product in products)
            {
                if (product.Cost > CMP)
                {
                    throw new Exception("Not enough money!");
                }
                if (slot == product.Slot)
                {
                    product.Subtract();
                    //this.Revenue += product.Cost;
                    Sold[product.Name] += 1;
                    Console.WriteLine($"{product.Name} {product.Cost} {CMP - product.Cost} \n{product.Message}");
                    using (StreamReader st = new StreamReader("Log.txt", true))
                    {
                        Console.WriteLine($"{DateTime.Now} {product.Name} {CMP} {CMP - product.Cost}");
                    }
                    CMP -= product.Cost;
                }
                else if (slot != product.Slot)
                {
                    throw new Exception("Does not exist!");
                }
            }
            return CMP;
        }

        public void Purchase(string slot)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
