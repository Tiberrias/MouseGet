using System.Collections.Generic;
using MouseGet.Model;

namespace MouseGet.Services.Interfaces
{
    public interface ICoordinatesPrintingService
    {
        string Print(List<MapCoordinate> mapCoordinates);
    }
}