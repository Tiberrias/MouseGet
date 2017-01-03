using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace MouseGet.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class MouseHookListenerWrapper : IMouseHookListenerWrapper
    {
        private readonly MouseHookListener _mouseHookListener;

        public event MouseEventHandler MouseClick;

        public bool Enabled
        {
            set { _mouseHookListener.Enabled = value; }
            get { return _mouseHookListener.Enabled; }
        }

        public MouseHookListenerWrapper()
        {
            _mouseHookListener = new MouseHookListener(new GlobalHooker());
            _mouseHookListener.MouseClick += (sender, args) => { MouseClick?.Invoke(sender, args); };
        }

        public void Dispose()
        {
            _mouseHookListener.Dispose();
        }


    }
}