using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Drink : Product
    {
        public Drink(string slot, string name, decimal cost) : base(slot, name, cost)
        {
            this.Message = "Glug Glug, Yum!";
        }
    }
}
