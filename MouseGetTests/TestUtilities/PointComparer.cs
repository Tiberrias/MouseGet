using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    public class PointComparer
    {
        private const double Delta = 0.000001;

        public static bool AreEqual(Point expected, Point actual)
        {
            Assert.AreEqual(expected.X, actual.X, Delta);
            Assert.AreEqual(expected.Y, actual.Y, Delta);

            return true;
        }
    }
}