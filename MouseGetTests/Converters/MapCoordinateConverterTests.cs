using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using MouseGet.Converters;
using MouseGet.Mapper;
using MouseGet.Model;
using MouseGetTests.TestUtilities;
using NUnit.Framework;

namespace MouseGetTests.Converters
{
    [TestFixture]
    public class MapCoordinateConverterTests
    {
        private MapCoordinateConverter _mapCoordinateConverter;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Convert_SimpleShift_ExpectedConversion()
        {
            MapTransformation mapTransformation = new MapTransformation()
            {
                Scale = 1,
                Rotation = 0,
                ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                MapReferencePoint = new Point() { X = 11, Y = 11 }
            };
            _mapCoordinateConverter = new MapCoordinateConverter(mapTransformation, new CoordinateMapper());

            MapCoordinate expectedCoordinate = new MapCoordinate() { X = 20, Y = 20, Z = 5 };
            Coordinate initialCoordinate = new Coordinate() { X = 10, Y = 10, Z = 5 };

            var result = _mapCoordinateConverter.Convert(initialCoordinate);

            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinate, result));
        }

        [Test]
        public void Convert_SimpleScale_ExpectedConversion()
        {
            MapTransformation mapTransformation = new MapTransformation()
            {
                Scale = 2,
                Rotation = 0,
                ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                MapReferencePoint = new Point() { X = 1, Y = 1 }
            };
            _mapCoordinateConverter = new MapCoordinateConverter(mapTransformation, new CoordinateMapper());

            MapCoordinate expectedCoordinate = new MapCoordinate() { X = 3, Y = 5, Z = 5 };
            Coordinate initialCoordinate = new Coordinate() { X = 2, Y = 3, Z = 5 };

            var result = _mapCoordinateConverter.Convert(initialCoordinate);

            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinate, result));
        }

        [Test]
        public void Convert_SimpleRotation_ExpectedConversion()
        {
            MapTransformation mapTransformation = new MapTransformation()
            {
                Scale = 1,
                Rotation = Math.PI / 2,
                ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                MapReferencePoint = new Point() { X = 1, Y = 1 }
            };
            _mapCoordinateConverter = new MapCoordinateConverter(mapTransformation, new CoordinateMapper());

            MapCoordinate expectedCoordinate = new MapCoordinate() { X = 0, Y = 1, Z = 5 };
            Coordinate initialCoordinate = new Coordinate() { X = 1, Y = 2, Z = 5 };

            var result = _mapCoordinateConverter.Convert(initialCoordinate);

            Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinate, result));
        }

        [Test]
        public void ConvertList_ComplicatedExample_ExpectedConversions()
        {
            MapTransformation mapTransformation = new MapTransformation()
            {
                Scale = 2,
                Rotation = -Math.PI / 3,
                ScreenReferencePoint = new Point() { X = 2, Y = 3 },
                MapReferencePoint = new Point() { X = 1, Y = 1 }
            };
            _mapCoordinateConverter = new MapCoordinateConverter(mapTransformation, new CoordinateMapper());

            List<MapCoordinate> expectedCoordinates = new List<MapCoordinate>()
            {
                new MapCoordinate() { X = 1, Y = 1, Z = 5 },
                new MapCoordinate() { X = 2 + 4 * Math.Sqrt(3), Y = 5- Math.Sqrt(3), Z = 6 },
                new MapCoordinate() { X = -1 - 3 * Math.Sqrt(3), Y = -2 + 2 * Math.Sqrt(3), Z = 7 }
            };

            List<Coordinate> initialCoordinates = new List<Coordinate>()
            {
                new Coordinate() { X = 2, Y = 3, Z = 5 },
                new Coordinate() { X = 3, Y = 7, Z = 6 },
                new Coordinate() { X = 0, Y = 0, Z = 7 }
            };

            var results = _mapCoordinateConverter.Convert(initialCoordinates);

            for (int i = 0; i < initialCoordinates.Count; i++)
            {
                Assert.IsTrue(MapCoordinateComparer.AreEqual(expectedCoordinates[i], results[i]));
            }

        }

    }
}