using MouseGet.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MouseGet
{
    public partial class MainForm : Form
    {
        CoordinatesLoggingService _coordinatesLoggingService;
        MouseHookListenerService _mouseHookListenerService;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            _coordinatesLoggingService = new CoordinatesLoggingService();
            _mouseHookListenerService = new MouseHookListenerService(_coordinatesLoggingService);
            _coordinatesLoggingService.CoordinatesLogChanged += OnCoordinatesLogChanged;
        }

        private void OnCoordinatesLogChanged(int numberOfLoggedCoordinates)
        {
            textBoxSavedNumber.Text = numberOfLoggedCoordinates.ToString();
        }

        private void SaveToFile(object sender, CancelEventArgs e)
        {
            string filename = saveFileDialogCoordinates.FileName;
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                File.AppendAllText(filename, _coordinatesLoggingService.GetCoordinatesLog());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd zapisu do pliku: " + ex.Message);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            DialogResult saveResult = saveFileDialogCoordinates.ShowDialog();
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            _coordinatesLoggingService.ClearCoordinatesLog();
        }

        private void OnZValueChanged(object sender, EventArgs e)
        {
            int ZValue = Convert.ToInt32(numericUpDownZValue.Value);
            _coordinatesLoggingService.SetCurrentZCoordinate(ZValue);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                ToggleLoggingClicks();
                SetStatusMessage();
            }
        }

        private void ToggleLoggingClicks()
        {
            if (!_mouseHookListenerService.IsListening)
            {
                _mouseHookListenerService.Start();
            }
            else
            {
                _mouseHookListenerService.Stop();
            }
        }

        private void SetStatusMessage()
        {
            if (_mouseHookListenerService.IsListening)
            {
                labelStatus.ForeColor = Color.LimeGreen;
                labelStatus.Text = "Zapisywanie koordynatów włączone";
            }
            else
            {
                labelStatus.ForeColor = Color.Crimson;
                labelStatus.Text = "Zapisywanie koordynatów wyłączone";
            }
        }
    }
}
