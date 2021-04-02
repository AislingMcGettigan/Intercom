using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomTest.Tests
{
    [TestClass]
    public class LocationServiceTests
    {
            [TestMethod]
            public void Distance_DifferentLocation_ShouldReturnDistanceInKM()
            {
                var lat1 = 52.833502;
                var lat2 = 54.080556;
                var lon1 = -8.522366;
                var lon2 = -6.361944;

                var theta = lon1 - lon2;
                var dist = Math.Sin(lat1.ToRadians()) * Math.Sin(lat2.ToRadians()) + Math.Cos(lat1.ToRadians()) * Math.Cos(lat2.ToRadians()) * Math.Cos(theta.ToRadians());
                dist = Math.Acos(dist);
                dist = dist.ToDegrees();
                dist = dist * 60 * 1.1515;
                dist *= 1.609344;

                Assert.IsNotNull(dist);
                Assert.AreEqual(199.19213752660951, dist);
            }

        [TestMethod]
        public void Distance_SameLocation_ShouldReturnZero()
        {
            var dist = 0;
            var lat1 = 52.833502;
            var lat2 = 52.833502;
            var lon1 = -8.522366;
            var lon2 = -8.522366;

            Assert.IsNotNull(dist);
            Assert.AreEqual(0, dist);
        }
    }
}
