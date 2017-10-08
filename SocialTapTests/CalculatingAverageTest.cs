using Logic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTapTests
{
    [TestClass]
    public class CalculatingAverageTest
    {
        [TestMethod]
        public void IsAverageTenAndSixCorrect()
        {
            //Arrange

            //Act
            var average = CalculatingAverage.GetAverage(10,6);

            //Assert
            Assert.AreEqual(average, 1,67);
        }
    }
}
