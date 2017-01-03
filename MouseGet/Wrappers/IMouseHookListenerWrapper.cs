using System.Windows.Forms;

namespace MouseGet.Wrappers
{
    public interface IMouseHookListenerWrapper
    {
        bool Enabled { get; set; }

        event MouseEventHandler MouseClick;

        void Dispose();
    }
}