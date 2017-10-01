using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using social_tap;

namespace SocialTapTests
{
    [TestClass]
    public class CalculatePercentageTest
    {
        [TestMethod]
        public void IsSimpleImagePercentageCalculationCorrect()
        {
            //Arrange
            Bitmap bmp = new Bitmap(@"../../TestData/Glass1.bmp");
            var simga = new SimpleImageAnalysis(bmp);

            //Act
            var percentage = simga.CalculatePercentageOfLiquid();

            //Assert
            Assert.AreEqual(percentage, 62);
        }
    }
}
