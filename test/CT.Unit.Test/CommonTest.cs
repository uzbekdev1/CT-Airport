using CT.Common.Dto;
using CT.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CT.Unit.Test
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void Calculation_Distance_Test()
        {
            // Arrange
            var srcLoc = new GeoLocation(4.763385, 52.309069);
            var tarLoc = new GeoLocation(-80.71119, 35.385139);
            var expected = 4158;

            // Act
            var actual = srcLoc.GetDistance(tarLoc);

            // Assert
            Assert.AreEqual(Math.Round(actual), expected);
        }
    }
}
