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
        public bool IsListeningForScreenCoordinates { get; private set; }
        public bool IsListeningForFirstReference { get; private set; }
        public bool IsListeningForSecondReference { get; private set; }

        public MouseHookListenerService(ICoordinatesLoggingService coordinatesLoggingService, IMouseHookListenerWrapper mouseHookListener)
        {
            _coordinatesLoggingService = coordinatesLoggingService;
            _mouseHookListener = mouseHookListener;
        }

        public void Start()
        {
            _mouseHookListener.MouseClick += OnMouseClick;
            _mouseHookListener.Enabled = true;
            IsListeningForScreenCoordinates = true;
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            Coordinate coordinate = new Coordinate() { X = e.X, Y = e.Y };
            if (IsListeningForFirstReference)
            {
                _coordinatesLoggingService.FirstReferencePoint = coordinate;
                IsListeningForFirstReference = false;
            }
            else if(IsListeningForSecondReference)
            {
                _coordinatesLoggingService.SecondReferencePoint = coordinate;
                IsListeningForFirstReference = false;
            }
            else
            {
                _coordinatesLoggingService.AddCoordinate(coordinate);
            }
            if (!IsListeningForScreenCoordinates)
            {
                _mouseHookListener.MouseClick -= OnMouseClick;
                _mouseHookListener.Enabled = false;
            }
        }

        public void Stop()
        {
            _mouseHookListener.MouseClick -= OnMouseClick;
            _mouseHookListener.Enabled = false;
            IsListeningForScreenCoordinates = false;
        }

        public void ListenForFirstReference()
        {
            IsListeningForFirstReference = true;
            if(IsListeningForScreenCoordinates) return;
            _mouseHookListener.MouseClick += OnMouseClick;
            _mouseHookListener.Enabled = true;
        }


        public void ListenForSecondReference()
        {
            IsListeningForSecondReference = true;
            if (IsListeningForScreenCoordinates) return;
            _mouseHookListener.MouseClick += OnMouseClick;
            _mouseHookListener.Enabled = true;
        }

        public void Dispose()
        {
            _mouseHookListener.Dispose();
        }

    }
}
