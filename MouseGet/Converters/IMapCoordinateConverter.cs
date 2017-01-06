using System.Collections.Generic;
using MouseGet.Model;

namespace MouseGet.Converters
{
    public interface IMapCoordinateConverter
    {
        List<MapCoordinate> Convert(List<Coordinate> coordinates);
        MapCoordinate Convert(Coordinate coordinate);
    }
}