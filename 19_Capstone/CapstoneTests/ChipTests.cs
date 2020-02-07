using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class ChipTests
    {
        [TestMethod]
        
        public void Subtract_Cost()
        {
            //Arrange
            Chip chip = new Chip("A1", "Chip", 1.50M);

            //Act
            decimal actualResult = chip.Purchase(chip, 10.00M);

            //Assert 
            Assert.AreEqual(8.50M, actualResult);
        }
        [TestMethod]

        public void Subtract_Cost_Expected_150()
        {
            //Arrange
            Chip chip = new Chip("A1", "Chip", 1.50M);

            //Act
            decimal actualResult = chip.Purchase(chip, 3.00M);

            //Assert 
            Assert.AreEqual(1.50M, actualResult);
        }
    }
}
