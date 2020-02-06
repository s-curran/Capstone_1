﻿using System;
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
        public string Quantity { get; private set; } = "5";
        public string Message { get; set; }
        public decimal Revenue { get; private set; } = 0.00M;
        
       
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

        public decimal Purchase(Product product, decimal CMP)
        {
             if (product.Cost > CMP)
             {
                 throw new Exception("Not enough money!");
             }
             else
             {
                 product.Subtract();
                 this.Revenue += product.Cost;
                 Console.WriteLine($"{product.Name} {product.Cost} {CMP - product.Cost} \n{product.Message}");
                 using (StreamReader st = new StreamReader(@"C: \Users\Student\git\c - module - 1 - capstone - team - 7\19_Capstone\Log.txt", true))
                 {
                     Console.WriteLine($"{DateTime.Now} {product.Name} {CMP} {CMP - product.Cost}");
                 }
                 CMP -= product.Cost;
             }
            return CMP;
        }

        /*public void Purchase(string slot)
        {
            throw new NotImplementedException();
        }*/
        #endregion

    }
}
