using System;
using MouseGet.Mapper.Interfaces;
using MouseGet.Model;
using MouseGet.Services.Interfaces;

namespace MouseGet.Services
{
    public class MapTransformationService : IMapTransformationService
    {
        private readonly IPointMapper _pointMapper;
        private const double Precision = 0.000001;

        public MapTransformationService(IPointMapper pointMapper)
        {
            _pointMapper = pointMapper;
        }

        public bool IsValidForTransformation(MapTransformationCoordinates mapTransformationCoordinates)
        {
            return !(Math.Abs(mapTransformationCoordinates.SecondScreenCoordinate.X - mapTransformationCoordinates.FirstScreenCoordinate.X) < Precision) &&
                   !(Math.Abs(mapTransformationCoordinates.SecondMapCoordinate.X - mapTransformationCoordinates.FirstMapCoordinate.X) < Precision);
        }

        public MapTransformation Transform(MapTransformationCoordinates mapTransformationCoordinates)
        {
            Point firstScreenPoint = _pointMapper.Map(mapTransformationCoordinates.FirstScreenCoordinate);
            Point secondScreenPoint = _pointMapper.Map(mapTransformationCoordinates.SecondScreenCoordinate);
            Point firstMapPoint = _pointMapper.Map(mapTransformationCoordinates.FirstMapCoordinate);
            Point secondMapPoint = _pointMapper.Map(mapTransformationCoordinates.SecondMapCoordinate);

            var result = new MapTransformation();

            double screenCoordinateDistance =
                Math.Sqrt(Math.Pow(secondScreenPoint.Y - firstScreenPoint.Y, 2) +
                          Math.Pow(secondScreenPoint.X - firstScreenPoint.X, 2));
            double mapCoordinateDistance =
                Math.Sqrt(Math.Pow(secondMapPoint.Y - firstMapPoint.Y, 2) +
                          Math.Pow(secondMapPoint.X - firstMapPoint.X, 2));
            result.Scale = mapCoordinateDistance / screenCoordinateDistance;

            double screenRotation =
                Math.Atan((secondScreenPoint.Y - firstScreenPoint.Y) /
                          (secondScreenPoint.X - firstScreenPoint.X));
            double mapRotation =
                Math.Atan((secondMapPoint.Y - firstMapPoint.Y) /
                          (secondMapPoint.X - firstMapPoint.X));
            result.Rotation = mapRotation - screenRotation;

            result.ScreenReferencePoint = firstScreenPoint;
            result.MapReferencePoint = firstMapPoint;

            return result;
        }
    }
}