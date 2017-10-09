using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace SocialTapTests
{
    [TestClass]
    public class CoordinatesConverterTest
    {
        [TestMethod]
        public void IsConverterReturnNotNull()
        {
            //Arrange 
            var lati = 54.719823;
            var longi = 25.320651;

            //Act
            var Data = CoordinatesConverter.GetConvertedCoordinates(lati, longi);

            //Assert
            Assert.IsNotNull(Data);

        }
    }
}