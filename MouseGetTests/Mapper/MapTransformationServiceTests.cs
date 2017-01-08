using System;
using MouseGet.Mapper;
using MouseGet.Mapper.Interfaces;
using MouseGet.Model;
using MouseGet.Services;
using MouseGet.Services.Interfaces;
using MouseGetTests.TestUtilities;
using NUnit.Framework;

namespace MouseGetTests.Mapper
{
    [TestFixture]
    public class MapTransformationServiceTests
    {
        private IPointMapper _pointMapper;
        private IMapTransformationService _mapTransformationService;

        [SetUp]
        public void SetUp()
        {
            _pointMapper = new PointMapper();
            _mapTransformationService = new MapTransformationService(_pointMapper);
        }

        [Test]
        public void Transform_SameGrid_ExpectedTransformation()
        {
            MapTransformation expectedTransformation =
                new MapTransformation()
                {
                    MapReferencePoint = new Point() { X = 1, Y = 1 },
                    ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                    Rotation = 0,
                    Scale = 1
                };

            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 2, Y = 3 },
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 1 },
                SecondScreenCoordinate = new Coordinate() { X = 2, Y = 3 }
            };


            var result = _mapTransformationService.Transform(mapTransformationCoordinates);

            Assert.AreEqual(expectedTransformation.Scale, result.Scale);
            Assert.AreEqual(expectedTransformation.Rotation, result.Rotation);
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.MapReferencePoint, result.MapReferencePoint));
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.ScreenReferencePoint, result.ScreenReferencePoint));
        }

        [Test]
        public void Transform_ShiftedGrid_ExpectedTransformation()
        {
            MapTransformation expectedTransformation =
                new MapTransformation()
                {
                    MapReferencePoint = new Point() { X = 1, Y = 1 },
                    ScreenReferencePoint = new Point() { X = 2, Y = 2 },
                    Rotation = 0,
                    Scale = 1
                };

            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 2, Y = 3 },
                FirstScreenCoordinate = new Coordinate() { X = 2, Y = 2 },
                SecondScreenCoordinate = new Coordinate() { X = 3, Y = 4 }
            };


            var result = _mapTransformationService.Transform(mapTransformationCoordinates);

            Assert.AreEqual(expectedTransformation.Scale, result.Scale);
            Assert.AreEqual(expectedTransformation.Rotation, result.Rotation);
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.MapReferencePoint, result.MapReferencePoint));
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.ScreenReferencePoint, result.ScreenReferencePoint));
        }

        [Test]
        public void Transform_RotatedGrid_ExpectedTransformation()
        {
            MapTransformation expectedTransformation =
                new MapTransformation()
                {
                    MapReferencePoint = new Point() { X = 1, Y = 1 },
                    ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                    Rotation = Math.PI / 2,
                    Scale = 1
                };

            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 2, Y = 2 },
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 1 },
                SecondScreenCoordinate = new Coordinate() { X = 0, Y = 2 }
            };


            var result = _mapTransformationService.Transform(mapTransformationCoordinates);

            Assert.AreEqual(expectedTransformation.Scale, result.Scale);
            Assert.AreEqual(expectedTransformation.Rotation, result.Rotation);
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.MapReferencePoint, result.MapReferencePoint));
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.ScreenReferencePoint, result.ScreenReferencePoint));
        }

        [Test]
        public void Transform_ScaledGrid_ExpectedTransformation()
        {
            MapTransformation expectedTransformation =
                new MapTransformation()
                {
                    MapReferencePoint = new Point() { X = 1, Y = 1 },
                    ScreenReferencePoint = new Point() { X = 1, Y = 1 },
                    Rotation = 0,
                    Scale = 2
                };

            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 3, Y = 3 },
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 1 },
                SecondScreenCoordinate = new Coordinate() { X = 2, Y = 2 }
            };


            var result = _mapTransformationService.Transform(mapTransformationCoordinates);

            Assert.AreEqual(expectedTransformation.Scale, result.Scale);
            Assert.AreEqual(expectedTransformation.Rotation, result.Rotation);
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.MapReferencePoint, result.MapReferencePoint));
            Assert.IsTrue(PointComparer.AreEqual(expectedTransformation.ScreenReferencePoint, result.ScreenReferencePoint));
        }

        [Test]
        public void IsValidForTransformation_ValidCoordinates_ReturnsTrue()
        {
            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 3, Y = 3 },
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 1 },
                SecondScreenCoordinate = new Coordinate() { X = 2, Y = 2 }
            };



            var result = _mapTransformationService.IsValidForTransformation(mapTransformationCoordinates);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidForTransformation_InvalidCoordinates_ReturnsFalse()
        {
            MapTransformationCoordinates mapTransformationCoordinates = new MapTransformationCoordinates()
            {
                FirstMapCoordinate = new MapCoordinate() { X = 1, Y = 1 },
                SecondMapCoordinate = new MapCoordinate() { X = 1, Y = 3 },
                FirstScreenCoordinate = new Coordinate() { X = 1, Y = 1 },
                SecondScreenCoordinate = new Coordinate() { X = 2, Y = 2 }
            };


            var result = _mapTransformationService.IsValidForTransformation(mapTransformationCoordinates);

            Assert.IsFalse(result);
        }

    }
}