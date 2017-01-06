using MouseGet.Mapper;
using MouseGet.Model;
using MouseGetTests.TestUtilities;
using NUnit.Framework;

namespace MouseGetTests.Mapper
{
    [TestFixture]
    public class CoordinateMapperTests
    {
        private CoordinateMapper _coordinateMapper;

        [SetUp]
        public void SetUp()
        {
            _coordinateMapper = new CoordinateMapper();
        }

        [Test]
        public void Map_MapsProperties()
        {
            MapCoordinate expectedCoordinate = new MapCoordinate() { X = 1, Y = 2, Z = 4 };
            Coordinate coordinate = new Coordinate() { X = 1, Y = 2, Z = 4 };

            var result = _coordinateMapper.Map(coordinate);

            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinate, result));
        }
    }
}