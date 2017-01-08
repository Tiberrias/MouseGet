using MouseGet.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MouseGet.Mapper;
using MouseGet.Services.Interfaces;
using MouseGet.Wrappers;

namespace MouseGet
{
    public partial class MainForm : Form
    {
        private ICoordinatesLoggingService _coordinatesLoggingService;
        private IMapTransformationService _mapTransformationService;
        private MouseHookListenerService _mouseHookListenerService;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            _coordinatesLoggingService = new CoordinatesLoggingService();
            _mapTransformationService = new MapTransformationService(new PointMapper());

            _mouseHookListenerService = new MouseHookListenerService(_coordinatesLoggingService, new MouseHookListenerWrapper());
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
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu do pliku: " + ex.Message);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            saveFileDialogCoordinates.ShowDialog();
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
            if (e.Control && e.KeyCode == Keys.E)
            {
                ToggleLoggingClicks();
                SetStatusMessage();
            }
        }

        private void ToggleLoggingClicks()
        {
            if (!_mouseHookListenerService.IsListeningForScreenCoordinates)
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
            if (_mouseHookListenerService.IsListeningForScreenCoordinates)
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

        private void SetReferenceListeningMessages()
        {
            if (_mouseHookListenerService.IsListeningForFirstReference)
            {
                labelFirstReference.ForeColor = Color.LimeGreen;
            }
            else
            {
                labelFirstReference.ForeColor = Color.Crimson;
            }
            if (_mouseHookListenerService.IsListeningForSecondReference)
            {
                labelSecondReference.ForeColor = Color.LimeGreen;
            }
            else
            {
                labelSecondReference.ForeColor = Color.Crimson;
            }
        }

        private void OnFirstReferenceClearClick(object sender, EventArgs e)
        {
            textBoxFirstReferenceMapX.Text = "X";
            textBoxFirstReferenceMapY.Text = "Y";
            textBoxFirstReferenceScreenX.Text = "X";
            textBoxFirstReferenceScreenY.Text = "Y";
        }

        private void OnSecondReferenceClrearClick(object sender, EventArgs e)
        {
            textBoxSecondReferenceMapX.Text = "X";
            textBoxSecondReferenceMapY.Text = "Y";
            textBoxSecondReferenceScreenX.Text = "X";
            textBoxSecondReferenceScreenY.Text = "Y";
        }
    }
}
