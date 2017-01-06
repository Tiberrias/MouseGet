using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    [TestFixture]
    public class MapCoordinateComparerTests
    {
        [Test]
        public void AreEqual_EqualCoordinates_ReturnsTrue()
        {
            MapCoordinate firstCoordinate = new MapCoordinate() { X = 1, Y = 2, Z = 4 };
            MapCoordinate secondCoordinate = new MapCoordinate() { X = 1, Y = 2, Z = 4 };

            Assert.IsTrue(MapCoordinateComparer.AreEqual(firstCoordinate, secondCoordinate));
        }

        [Test]
        public void AreEqual_NotEqualCoordinates_ThrowsAssertionException()
        {

            MapCoordinate firstCoordinate = new MapCoordinate() { X = 1, Y = 2, Z = 4 };
            MapCoordinate secondCoordinate = new MapCoordinate() { X = 0.9, Y = 2.1, Z = 4 };

            Assert.Throws<AssertionException>(() =>  MapCoordinateComparer.AreEqual(firstCoordinate, secondCoordinate));
        }

    }
}