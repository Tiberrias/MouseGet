using MouseGet.Model;

namespace MouseGet.Services.Interfaces
{
    public interface IMapTransformationService
    {
        MapTransformation Transform(MapTransformationCoordinates mapTransformationCoordinates);

        bool IsValidForTransformation(MapTransformationCoordinates mapTransformationCoordinates);
    }
}