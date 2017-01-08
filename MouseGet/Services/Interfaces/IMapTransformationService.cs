using MouseGet.Model;

namespace MouseGet.Services.Interfaces
{
    public interface IMapTransformationService
    {
        MapTransformation Transform(Coordinate firstScreenCoordinate,
            MapCoordinate firstMapCoordinate,
            Coordinate secondScreenCoordinate,
            MapCoordinate secondMapCoordinate);

        bool IsValidForTransformation(Coordinate firstScreenCoordinate, 
            MapCoordinate firstMapCoordinate,
            Coordinate secondScreenCoordinate,
            MapCoordinate secondMapCoordinate);
    }
}