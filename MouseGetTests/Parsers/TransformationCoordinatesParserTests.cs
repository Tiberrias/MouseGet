using MouseGet.Model;
using MouseGet.Parsers;
using MouseGetTests.TestUtilities;
using NUnit.Framework;

namespace MouseGetTests.Parsers
{
    [TestFixture]
    public class TransformationCoordinatesParserTests
    {
        private TransformationCoordinatesParser _transformationCoordinatesParser;

        [SetUp]
        public void SetUp()
        {
            _transformationCoordinatesParser = new TransformationCoordinatesParser();
        }

        [Test]
        public void Parse_ValidStrings_ParsedProperly()
        {
            string firstScreenCoordinateX = "1";
            string firstScreenCoordinateY = "2";
            string firstMapCoordinateX = "3";
            string firstMapCoordinateY = "4";
            string secondScreenCoordinateX = "5";
            string secondScreenCoordinateY = "6";
            string secondMapCoordinateX = "7";
            string secondMapCoordinateY = "8";

            MapTransformationCoordinates expectedCoordinates = new MapTransformationCoordinates()
            {
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 2 },
                FirstMapCoordinate = new MapCoordinate() { X = 3, Y = 4 },
                SecondScreenCoordinate = new Coordinate() { X = 5, Y = 6 },
                SecondMapCoordinate = new MapCoordinate() { X = 7, Y = 8 }
            };

            var result = _transformationCoordinatesParser.Parse(
                firstScreenCoordinateX,
                firstScreenCoordinateY,
                firstMapCoordinateX,
                firstMapCoordinateY,
                secondScreenCoordinateX,
                secondScreenCoordinateY,
                secondMapCoordinateX,
                secondMapCoordinateY);

            Assert.IsTrue(CoordinateComparer.AreEqual(expectedCoordinates.FirstScreenCoordinate, result.FirstScreenCoordinate));
            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinates.FirstMapCoordinate, result.FirstMapCoordinate));
            Assert.IsTrue(CoordinateComparer.AreEqual(expectedCoordinates.SecondScreenCoordinate, result.SecondScreenCoordinate));
            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinates.SecondMapCoordinate, result.SecondMapCoordinate));
        }
    }
}