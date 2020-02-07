using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void Subtract_Cost()
        {
            //Arrange
            Candy candy = new Candy("A1", "Candy", 0.75M);

            //Act
            decimal actualResult = candy.Purchase(candy, 8.00M);

            //Assert 
            Assert.AreEqual(7.25M, actualResult);
        }
        [TestMethod]
        public void Subtract_Cost_to_0()
        {
            //Arrange
            Candy candy = new Candy("A1", "Candy", 0.75M);

            //Act
            decimal actualResult = candy.Purchase(candy, 0.75M);

            //Assert 
            Assert.AreEqual(0.00M, actualResult);
        }
        [TestMethod]
        public void Subtract_Cost_to_1()
        {
            //Arrange
            Candy candy = new Candy("A1", "Candy", 1.00M);

            //Act
            decimal actualResult = candy.Purchase(candy, 2.00M);

            //Assert 
            Assert.AreEqual(1.00M, actualResult);
        }
    }
   
}
