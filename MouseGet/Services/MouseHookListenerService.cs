using MouseGet.Model;
using MouseGet.Services.Interfaces;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Windows.Forms;

namespace MouseGet.Services
{
    public class MouseHookListenerService : IDisposable
    {
        private readonly MouseHookListener _mouseHookListener;
        private readonly ICoordinatesLoggingService _coordinatesLoggingService;
        public bool IsListening { get; private set; }

        public MouseHookListenerService(ICoordinatesLoggingService coordinatesLoggingService)
        {
            _mouseHookListener = new MouseHookListener(new GlobalHooker());
            _coordinatesLoggingService = coordinatesLoggingService;
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
