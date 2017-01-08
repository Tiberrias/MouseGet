using MouseGet.Mapper.Interfaces;
using MouseGet.Model;

namespace MouseGet.Mapper
{
    public class PointMapper : IPointMapper
    {
        public Point Map(Coordinate coordinate)
        {
            return new Point()
            {
                X = coordinate.X,
                Y = coordinate.Y
            };
        }

        public Point Map(MapCoordinate coordinate)
        {
            return new Point()
            {
                X = coordinate.X,
                Y = coordinate.Y
            };
        }
    }
}