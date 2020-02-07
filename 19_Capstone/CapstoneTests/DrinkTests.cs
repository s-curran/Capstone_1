using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapstoneTests
{
    [TestClass]
    public class DrinkTests
    {
        [TestMethod]
        public void Subtract_Cost()
        {
            //Arrange
            Drink drink = new Drink("A1", "Drink", 2.75M);

            //Act
            decimal actualResult = drink.Purchase(drink, 12.00M);

            //Assert 
            Assert.AreEqual(9.25M, actualResult);
        }
        [TestMethod]
        public void Subtract_Cost_305()
        {
            //Arrange
            Drink drink = new Drink("A1", "Drink", 3.05M);

            //Act
            decimal actualResult = drink.Purchase(drink, 8.15M);

            //Assert 
            Assert.AreEqual(5.10M, actualResult);
        }
    }
}
