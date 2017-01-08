using System;
using System.Collections.Generic;
using System.Linq;
using MouseGet.Mapper.Interfaces;
using MouseGet.Model;

namespace MouseGet.Converters
{
    public class MapCoordinateConverter : IMapCoordinateConverter
    {
        private readonly ICoordinateMapper _coordinateMapper;
        private MapTransformation _mapTransformation;

        public MapTransformation MapTransformation
        {
            set { _mapTransformation = value; }
        }

        public MapCoordinateConverter(ICoordinateMapper coordinateMapper)
        {
            _coordinateMapper = coordinateMapper;
        }

        public MapCoordinate Convert(Coordinate coordinate)
        {
            MapCoordinate baseCoordinate = _coordinateMapper.Map(coordinate);
            MapCoordinate result = new MapCoordinate() { Z = baseCoordinate.Z };

            result.Y = _mapTransformation.MapReferencePoint.Y +
                       _mapTransformation.Scale * Math.Sin(_mapTransformation.Rotation) *
                       (baseCoordinate.X - _mapTransformation.ScreenReferencePoint.X) +
                       _mapTransformation.Scale * Math.Cos(_mapTransformation.Rotation) *
                       (baseCoordinate.Y - _mapTransformation.ScreenReferencePoint.Y);

            result.X = _mapTransformation.MapReferencePoint.X +
                       _mapTransformation.Scale * Math.Cos(_mapTransformation.Rotation) *
                       (baseCoordinate.X - _mapTransformation.ScreenReferencePoint.X) -
                       _mapTransformation.Scale * Math.Sin(_mapTransformation.Rotation) *
                       (baseCoordinate.Y - _mapTransformation.ScreenReferencePoint.Y);

            return result;
        }

        public List<MapCoordinate> Convert(List<Coordinate> coordinates)
        {
            return coordinates.Select(Convert).ToList();
        }

    }
}