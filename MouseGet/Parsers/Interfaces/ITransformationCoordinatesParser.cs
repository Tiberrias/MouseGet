using MouseGet.Model;

namespace MouseGet.Parsers.Interfaces
{
    public interface ITransformationCoordinatesParser
    {
        MapTransformationCoordinates Parse(string firstScreenCoordinateX,
            string firstScreenCoordinateY,
            string firstMapCoordinateX,
            string firstMapCoordinateY,
            string secondScreenCoordinateX,
            string secondScreenCoordinateY,
            string secondMapCoordinateX,
            string secondMapCoordinateY);

    }
}