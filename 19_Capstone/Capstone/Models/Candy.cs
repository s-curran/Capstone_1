using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Candy : Product
    {
        public Candy(string slot, string name, decimal cost) : base(slot, name, cost)
        {
            this.Message = "Munch Munch, Yum!";
        }
    }
}
