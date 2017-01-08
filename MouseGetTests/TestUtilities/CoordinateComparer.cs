using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    public class CoordinateComparer
    {
        public static bool AreEqual(Coordinate expected, Coordinate actual)
        {
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);

            return true;
        }
    }
}