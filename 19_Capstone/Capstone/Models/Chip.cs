using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Chip : Product
    {
        public Chip(string slot, string name, decimal cost) : base(slot, name, cost)
        {
           
            this.Message = "Crunch Crunch, Yum!";
        }

    
    }
}
