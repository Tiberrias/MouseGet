using MouseGet.Model;
using MouseGet.Services;
using NUnit.Framework;
using System;

namespace MouseGetTests.Services
{
    [TestFixture]
    class CoordinatesLoggingServiceTests
    {
        private CoordinatesLoggingService _coordinatesLoggingService;

        [SetUp]
        public void SetUp()
        {
            _coordinatesLoggingService = new CoordinatesLoggingService();
        }

        [Test]
        public void GetCoordinatesLog_EmpyList_EmptyString()
        {
            Assert.IsEmpty(_coordinatesLoggingService.GetCoordinatesLog());
        }

        [Test]
        public void AddCoordinate_ValidCoordinate_CoordinateAdded()
        {
            _coordinatesLoggingService.AddCoordinate(new Coordinate());

            Assert.IsNotEmpty(_coordinatesLoggingService.GetCoordinatesLog());
        }

        [Test]
        public void AddCoordinate_NullCoordinate_ThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => _coordinatesLoggingService.AddCoordinate(null));
        }

        [Test]
        public void AddCoordinate_ValidCoordinate_RaisesEvent()
        {
            bool eventFired = false;
            _coordinatesLoggingService.CoordinatesLogChanged += (i) => eventFired = true;

            _coordinatesLoggingService.AddCoordinate(new Coordinate());

            Assert.IsTrue(eventFired);
        }

        [Test]
        public void ClearCoordinates_RaisesEvent()
        {
            bool eventFired = false;
            _coordinatesLoggingService.CoordinatesLogChanged += (i) => eventFired = true;

            _coordinatesLoggingService.ClearCoordinatesLog();

            Assert.IsTrue(eventFired);
        }

        [Test]
        public void ClearCoordinate_ClearsCoordinates()
        {
            _coordinatesLoggingService.AddCoordinate(new Coordinate());
            _coordinatesLoggingService.AddCoordinate(new Coordinate());

            _coordinatesLoggingService.ClearCoordinatesLog();

            Assert.IsEmpty(_coordinatesLoggingService.GetCoordinatesLog());
        }

        [Test]
        public void SetCurrentZCoordinate_SomeValue_SetsCoordinateZValue()
        {
            var someZValue = 42;
            _coordinatesLoggingService.AddCoordinate(new Coordinate() { X = 1, Y = 1 });

            Assert.IsFalse(_coordinatesLoggingService.GetCoordinatesLog().Contains(someZValue.ToString()));

            _coordinatesLoggingService.SetCurrentZCoordinate(someZValue);
            _coordinatesLoggingService.AddCoordinate(new Coordinate() { X = 2, Y = 2 });

            Assert.IsTrue(_coordinatesLoggingService.GetCoordinatesLog().Contains(someZValue.ToString()));
        }

        [Test]
        public void CoordinatesLogChanged_NoCoordinatesAdded_ReturnsZero()
        {
            int countAddedCoordinates = 0;
            _coordinatesLoggingService.CoordinatesLogChanged += (i) => countAddedCoordinates = i;

            Assert.AreEqual(0, countAddedCoordinates);
        }

        [Test]
        public void CoordinatesLogChanged_CoordinatesAddedAndCleared_ReturnsZero()
        {
            int countAddedCoordinates = 0;
            _coordinatesLoggingService.CoordinatesLogChanged += (i) => countAddedCoordinates = i;

            _coordinatesLoggingService.AddCoordinate(new Coordinate());
            _coordinatesLoggingService.AddCoordinate(new Coordinate());
            _coordinatesLoggingService.ClearCoordinatesLog();

            Assert.AreEqual(0, countAddedCoordinates);
        }

        [Test]
        public void CoordinatesLogChanged_SomeCoordinatesAdded_ReturnsNumberOfCoordinatesAdded()
        {
            int countAddedCoordinates = 0;
            _coordinatesLoggingService.CoordinatesLogChanged += (i) => countAddedCoordinates = i;

            _coordinatesLoggingService.AddCoordinate(new Coordinate());
            _coordinatesLoggingService.AddCoordinate(new Coordinate());

            Assert.AreEqual(2, countAddedCoordinates);
        }

    }
}
