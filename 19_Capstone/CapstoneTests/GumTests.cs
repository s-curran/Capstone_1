using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class GumTests
    {
        [TestMethod]
        
        public void Subtract_Cost()
        {
            //Arrange
            Gum gum = new Gum("A1", "Gum", 3.10M);

            //Act
            decimal actualResult = gum.Purchase(gum, 12.00M);

            //Assert 
            Assert.AreEqual(8.90M, actualResult);
        }
        [TestMethod]

        public void Subtract_Cost_to_510()
        {
            //Arrange
            Gum gum = new Gum("A1", "Gum", 1.90M);

            //Act
            decimal actualResult = gum.Purchase(gum, 7.00M);

            //Assert 
            Assert.AreEqual(5.10M, actualResult);
        }
    }
}

