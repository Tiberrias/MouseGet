using System;
using MouseGet.Mapper.Interfaces;
using MouseGet.Model;
using MouseGet.Services.Interfaces;

namespace MouseGet.Services
{
    public class MapTransformationService : IMapTransformationService
    {
        private readonly IPointMapper _pointMapper;

        public MapTransformationService(IPointMapper pointMapper)
        {
            _pointMapper = pointMapper;
        }

        public MapTransformation Transform(Coordinate firstScreenCoordinate,
            MapCoordinate firstMapCoordinate,
            Coordinate secondScreenCoordinate,
            MapCoordinate secondMapCoordinate)
        {
            Point firstScreenPoint = _pointMapper.Map(firstScreenCoordinate);
            Point secondScreenPoint = _pointMapper.Map(secondScreenCoordinate);
            Point firstMapPoint = _pointMapper.Map(firstMapCoordinate);
            Point secondMapPoint = _pointMapper.Map(secondMapCoordinate);

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
            result.MapReferencePoint = secondScreenPoint;
            
            return result;
        }
    }
}