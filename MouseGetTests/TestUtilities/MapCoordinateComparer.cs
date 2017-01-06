using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    public class MapCoordinateComparer
    {
        private const double Delta = 0.000001;

        public static bool AreEqual(MapCoordinate expected, MapCoordinate actual)
        {
            Assert.AreEqual(expected.X, actual.X, Delta);
            Assert.AreEqual(expected.Y, actual.Y, Delta);
            Assert.AreEqual(expected.Z, actual.Z, Delta);

            return true;
        }
    }
}