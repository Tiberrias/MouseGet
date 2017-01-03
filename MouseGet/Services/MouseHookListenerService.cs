using MouseGet.Model;
using MouseGet.Services.Interfaces;
using System;
using System.Windows.Forms;
using MouseGet.Wrappers;

namespace MouseGet.Services
{
    public class MouseHookListenerService : IDisposable
    {
        private readonly IMouseHookListenerWrapper _mouseHookListener;
        private readonly ICoordinatesLoggingService _coordinatesLoggingService;
        public bool IsListening { get; private set; }

        public MouseHookListenerService(ICoordinatesLoggingService coordinatesLoggingService, IMouseHookListenerWrapper mouseHookListener)
        {
            _coordinatesLoggingService = coordinatesLoggingService;
            _mouseHookListener = mouseHookListener;
        }

        public void Start()
        {
            _mouseHookListener.MouseClick += OnMouseClick;
            _mouseHookListener.Enabled = true;
            IsListening = true;
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            Coordinate coordinate = new Coordinate() { X = e.X, Y = e.Y };
            _coordinatesLoggingService.AddCoordinate(coordinate);
        }

        public void Stop()
        {
            _mouseHookListener.MouseClick -= OnMouseClick;
            _mouseHookListener.Enabled = false;
            IsListening = false;
        }

        public void Dispose()
        {
            _mouseHookListener.Dispose();
        }

    }
}
