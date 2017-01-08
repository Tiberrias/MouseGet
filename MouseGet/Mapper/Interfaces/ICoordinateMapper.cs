using MouseGet.Model;

namespace MouseGet.Mapper.Interfaces
{
    public interface ICoordinateMapper
    {
        MapCoordinate Map(Coordinate coordinate);
    }
}