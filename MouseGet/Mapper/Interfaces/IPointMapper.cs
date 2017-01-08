using MouseGet.Model;

namespace MouseGet.Mapper.Interfaces
{
    public interface IPointMapper
    {
        Point Map(MapCoordinate coordinate);
        Point Map(Coordinate coordinate);
    }
}