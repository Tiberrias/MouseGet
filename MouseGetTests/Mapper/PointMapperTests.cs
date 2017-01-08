using MouseGet.Mapper;
using MouseGet.Model;
using MouseGetTests.TestUtilities;
using NUnit.Framework;

namespace MouseGetTests.Mapper
{
    [TestFixture]
    public class PointMapperTests
    {
        private PointMapper _pointMapper;

        [SetUp]
        public void SetUp()
        {
            _pointMapper = new PointMapper();
        }

        [Test]
        public void Map_Coordinate_MapsProperties()
        {
            Point expectedPoint = new Point() { X = 1, Y = 2 };
            Coordinate coordinate = new Coordinate() { X = 1, Y = 2, Z = 4 };

            var result = _pointMapper.Map(coordinate);

            Assert.IsTrue(PointComparer.AreEqual(expectedPoint, result));
        }

        [Test]
        public void Map_MapCoordinate_MapsProperties()
        {
            Point expectedPoint = new Point() { X = 1.1, Y = 2 };
            MapCoordinate coordinate = new MapCoordinate() { X = 1.1, Y = 2, Z = 4.1 };

            var result = _pointMapper.Map(coordinate);

            Assert.IsTrue(PointComparer.AreEqual(expectedPoint, result));
        }
    }
}