using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void IsTwoPlusTwoEqualFour()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var sum = calculator.sum(2, 2);
              
            //Assert
            Assert.AreEqual(sum, 4);
        }
    }
}
