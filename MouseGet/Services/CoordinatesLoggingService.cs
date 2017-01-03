using System.Collections.Generic;
using System.Text;
using System;
using MouseGet.Services.Interfaces;
using MouseGet.Model;

namespace MouseGet.Services
{
    
    public class CoordinatesLoggingService : ICoordinatesLoggingService
    {
        private readonly List<Coordinate> _coordinates;
        private int _currentZCoordinate;

        public event Action<int> CoordinatesLogChanged = delegate { };

        public CoordinatesLoggingService()
        {
            _coordinates = new List<Coordinate>();
        }

        public void AddCoordinate(Coordinate coordinate)
        {
            coordinate.Z = _currentZCoordinate;
            _coordinates.Add(coordinate);
            HandleCoordinatesChanged();
        }

        public void ClearCoordinatesLog()
        {
            _coordinates.Clear();
            HandleCoordinatesChanged();
        }

        public string GetCoordinatesLog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            _coordinates.ForEach(x => stringBuilder.AppendLine(x.ToString()));
            return stringBuilder.ToString();
        }

        public void SetCurrentZCoordinate(int z)
        {
            _currentZCoordinate = z;
        }

        private void HandleCoordinatesChanged()
        {
            CoordinatesLogChanged?.Invoke(_coordinates.Count);
        }

    }
}
