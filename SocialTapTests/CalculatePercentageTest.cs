using System.Drawing;
using Logic.ImageAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ICalculateLiquidPercentage simga = new SimpleImageAnalysis(bmp);

            //Act
            var percentage = simga.CalculatePercentageOfLiquid();

            //Assert
            Assert.AreEqual(percentage, 62);
        }
    }
}
