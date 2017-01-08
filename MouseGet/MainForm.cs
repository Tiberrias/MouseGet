using MouseGet.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MouseGet.Converters;
using MouseGet.Mapper;
using MouseGet.Model;
using MouseGet.Parsers;
using MouseGet.Parsers.Interfaces;
using MouseGet.Services.Interfaces;
using MouseGet.Wrappers;

namespace MouseGet
{
    public partial class MainForm : Form
    {
        private ICoordinatesLoggingService _coordinatesLoggingService;
        private IMapTransformationService _mapTransformationService;
        private IMapCoordinateConverter _mapCoordinateConverter;
        private ICoordinatesPrintingService _coordinatesPrintingService;
        private ITransformationCoordinatesParser _transformationCoordinatesParser;
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
            _mapCoordinateConverter = new MapCoordinateConverter(new CoordinateMapper());
            _coordinatesPrintingService = new CoordinatesPrintingService();
            _transformationCoordinatesParser = new TransformationCoordinatesParser();

            _mouseHookListenerService = new MouseHookListenerService(_coordinatesLoggingService, new MouseHookListenerWrapper());
            _coordinatesLoggingService.CoordinatesLogChanged += OnCoordinatesLogChanged;
        }

        private void OnCoordinatesLogChanged(int numberOfLoggedCoordinates)
        {
            textBoxSavedNumber.Text = numberOfLoggedCoordinates.ToString();
            if (_coordinatesLoggingService.FirstReferencePoint != null)
            {
                textBoxFirstReferenceScreenX.Text = _coordinatesLoggingService.FirstReferencePoint.X.ToString();
                textBoxFirstReferenceScreenY.Text = _coordinatesLoggingService.FirstReferencePoint.Y.ToString();
            }
            if (_coordinatesLoggingService.SecondReferencePoint != null)
            {
                textBoxSecondReferenceScreenX.Text = _coordinatesLoggingService.SecondReferencePoint.X.ToString();
                textBoxSecondReferenceScreenY.Text = _coordinatesLoggingService.SecondReferencePoint.Y.ToString();
            }
            SetReferenceListeningMessages();
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

                File.AppendAllText(filename,
                    _coordinatesPrintingService.Print(
                        _mapCoordinateConverter.Convert(
                            _coordinatesLoggingService.GetCoordinates()
                            )
                        )
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu do pliku: " + ex.Message);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            try
            {
                var mapTransformationCoordinates = _transformationCoordinatesParser.Parse(
                    textBoxFirstReferenceScreenX.Text,
                    textBoxFirstReferenceScreenY.Text,
                    textBoxFirstReferenceMapX.Text,
                    textBoxFirstReferenceMapY.Text,
                    textBoxSecondReferenceScreenX.Text,
                    textBoxSecondReferenceScreenY.Text,
                    textBoxSecondReferenceMapX.Text,
                    textBoxSecondReferenceMapY.Text
                );
                if (!_mapTransformationService.IsValidForTransformation(mapTransformationCoordinates))
                {
                    throw new ArgumentException("Wybrane punkty referencyjne nie pozwalają na obliczenie transformacji ukłądu współrzędnych");
                }
                _mapCoordinateConverter.MapTransformation = _mapTransformationService.Transform(mapTransformationCoordinates);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
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
                if (!_mouseHookListenerService.IsListeningForFirstReference &&
                    !_mouseHookListenerService.IsListeningForSecondReference)
                {
                    ToggleLoggingClicks();
                    SetStatusMessage();
                }
            }
            if (e.Control && e.KeyCode == Keys.D1)
            {
                if (!_mouseHookListenerService.IsListeningForScreenCoordinates &&
                    !_mouseHookListenerService.IsListeningForSecondReference)
                {
                    ToggleLoggingFirstReference();
                    SetReferenceListeningMessages();
                }
            }
            if (e.Control && e.KeyCode == Keys.D2)
            {
                if (!_mouseHookListenerService.IsListeningForFirstReference &&
                    !_mouseHookListenerService.IsListeningForScreenCoordinates)
                {
                    ToggleLoggingSecondReference();
                    SetReferenceListeningMessages();
                }
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

        private void ToggleLoggingFirstReference()
        {
            if (!_mouseHookListenerService.IsListeningForFirstReference)
            {
                _mouseHookListenerService.ListenForFirstReference();
            }
            else
            {
                _mouseHookListenerService.StopListeningForFisrtReference();
            }
        }

        private void ToggleLoggingSecondReference()
        {
            if (!_mouseHookListenerService.IsListeningForSecondReference)
            {
                _mouseHookListenerService.ListenForSecondReference();
            }
            else
            {
                _mouseHookListenerService.StopListeningForSecondReference();
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
            _coordinatesLoggingService.FirstReferencePoint = null;
        }

        private void OnSecondReferenceClearClick(object sender, EventArgs e)
        {
            textBoxSecondReferenceMapX.Text = "X";
            textBoxSecondReferenceMapY.Text = "Y";
            textBoxSecondReferenceScreenX.Text = "X";
            textBoxSecondReferenceScreenY.Text = "Y";
            _coordinatesLoggingService.SecondReferencePoint = null;
        }
    }
}
