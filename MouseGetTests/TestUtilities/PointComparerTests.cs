using MouseGet.Model;
using NUnit.Framework;

namespace MouseGetTests.TestUtilities
{
    [TestFixture]
    public class PointComparerTests
    {
        [Test]
        public void AreEqual_EqualPoints_ReturnsTrue()
        {
            Point firstPoint = new Point() { X = 1, Y = 2 };
            Point secondPoint = new Point() { X = 1, Y = 2 };

            Assert.IsTrue(PointComparer.AreEqual(firstPoint, secondPoint));
        }

        [Test]
        public void AreEqual_NotEqualPoints_ThrowsAssertionException()
        {

            Point firstPoint = new Point() { X = 1, Y = 2 };
            Point secondPoint = new Point() { X = 0.9, Y = 2.1 };

            Assert.Throws<AssertionException>(() => PointComparer.AreEqual(firstPoint, secondPoint));
        }

    }
}