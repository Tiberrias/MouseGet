using MouseGet.Model;
using System;

namespace MouseGet.Services.Interfaces
{

    public interface ICoordinatesLoggingService
    {
        event Action<int> CoordinatesLogChanged;

        void AddCoordinate(Coordinate coordinate);

        void ClearCoordinatesLog();

        string GetCoordinatesLog();

        void SetCurrentZCoordinate(int z);
    }
}
