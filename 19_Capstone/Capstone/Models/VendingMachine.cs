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
        public decimal TotalSales = 0;
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

                    }
                }
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
