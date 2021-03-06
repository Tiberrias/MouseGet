﻿using MouseGet.Mapper.Interfaces;
using MouseGet.Model;

namespace MouseGet.Mapper
{
    public class CoordinateMapper : ICoordinateMapper
    {
        public MapCoordinate Map(Coordinate coordinate)
        {
            return new MapCoordinate()
            {
                X = coordinate.X,
                Y = coordinate.Y,
                Z = coordinate.Z
            };
        }
    }
}