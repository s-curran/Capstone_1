using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Gum : Product
    {
        public Gum(string slot, string name, decimal cost) : base(slot, name, cost)
        {
            this.Message = "Chew Chew, Yum!";
        }
    }
}
