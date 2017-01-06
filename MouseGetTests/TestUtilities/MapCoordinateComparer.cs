using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    public class MapCoordinateComparer
    {
        public static bool AreEqual(MapCoordinate expected, MapCoordinate actual)
        {
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);

            return true;
        }
    }
}