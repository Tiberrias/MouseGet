using MouseGet.Model;
using System;
using System.Collections.Generic;

namespace MouseGet.Services.Interfaces
{

    public interface ICoordinatesLoggingService
    {
        event Action<int> CoordinatesLogChanged;

        void AddCoordinate(Coordinate coordinate);

        void ClearCoordinatesLog();

        string GetCoordinatesLog();

        void SetCurrentZCoordinate(int z);

        List<Coordinate> GetCoordinates();

        Coordinate FirstReferencePoint { get; set; }

        Coordinate SecondReferencePoint { get; set; }
    }
}
