using System;
using System.Windows.Forms;
using Moq;
using MouseGet.Model;
using MouseGet.Services;
using MouseGet.Services.Interfaces;
using MouseGet.Wrappers;
using NUnit.Framework;

namespace MouseGetTests.Services
{
    [TestFixture]
    public class MouseHookListenerServiceTests
    {
        private MouseHookListenerService _mouseHookListenerService;
        private Mock<ICoordinatesLoggingService> _coordinatesLoggingService;
        private Mock<IMouseHookListenerWrapper> _mouseHookListener;

        [SetUp]
        public void SetUp()
        {
            _mouseHookListener = new Mock<IMouseHookListenerWrapper>();
            _coordinatesLoggingService = new Mock<ICoordinatesLoggingService>();
            _mouseHookListenerService = new MouseHookListenerService(_coordinatesLoggingService.Object, _mouseHookListener.Object);
        }

        [Test]
        public void Start_MouseHookListenerEnabled()
        {
            _mouseHookListener.SetupProperty(x => x.Enabled);

            _mouseHookListenerService.Start();

            Assert.IsTrue(_mouseHookListener.Object.Enabled);
        }

        [Test]
        public void Start_IsListeningSet()
        {
            _mouseHookListenerService.Start();

            Assert.IsTrue(_mouseHookListenerService.IsListeningForScreenCoordinates);
        }

        [Test]
        public void Stop_MouseHookListenerDisabled()
        {
            _mouseHookListener.SetupProperty(x => x.Enabled);

            _mouseHookListenerService.Stop();

            Assert.IsFalse(_mouseHookListener.Object.Enabled);
        }

        [Test]
        public void Stop_IsListeningSet()
        {
            _mouseHookListenerService.Stop();

            Assert.IsFalse(_mouseHookListenerService.IsListeningForScreenCoordinates);
        }

        [Test]
        public void Dispose_DisposesListener()
        {
            _mouseHookListenerService.Dispose();

            _mouseHookListener.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void OnMouseClick_AddsCoordinate()
        {
            _mouseHookListenerService.Start();
            _mouseHookListener.Raise(x => x.MouseClick += (sender, args) => { }, null, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
            
            _coordinatesLoggingService.Verify(x => x.AddCoordinate(It.IsAny<Coordinate>()), Times.Once);
        }
    }
}