using System.Collections.Generic;
using MouseGet.Model;

namespace MouseGet.Converters
{
    public interface IMapCoordinateConverter
    {
        MapTransformation MapTransformation { set; }

        List<MapCoordinate> Convert(List<Coordinate> coordinates);
        MapCoordinate Convert(Coordinate coordinate);
    }
}