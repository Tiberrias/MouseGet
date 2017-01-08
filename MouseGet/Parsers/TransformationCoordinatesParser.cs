using System;
using MouseGet.Model;
using MouseGet.Parsers.Interfaces;

namespace MouseGet.Parsers
{
    public class TransformationCoordinatesParser : ITransformationCoordinatesParser
    {
        public MapTransformationCoordinates Parse(string firstScreenCoordinateX,
            string firstScreenCoordinateY,
            string firstMapCoordinateX,
            string firstMapCoordinateY,
            string secondScreenCoordinateX,
            string secondScreenCoordinateY,
            string secondMapCoordinateX,
            string secondMapCoordinateY)
        {
            {
                Coordinate firstScreenCoordinate = new Coordinate();
                MapCoordinate firstMapCoordinate = new MapCoordinate();
                Coordinate secondScreenCoordinate = new Coordinate();
                MapCoordinate secondMapCoordinate = new MapCoordinate();

                
                if (!int.TryParse(firstScreenCoordinateX, out firstScreenCoordinate.X))
                {
                    throw new ArgumentException("Nieprawidłowa wartość X koordynatu pierwszego punktu referencyjnego");
                }
                if (!int.TryParse(firstScreenCoordinateY, out firstScreenCoordinate.Y))
                {
                    throw new ArgumentException("Nieprawidłowa wartość Y koordynatu pierwszego punktu referencyjnego");
                }
                if (!double.TryParse(firstMapCoordinateX, out firstMapCoordinate.X))
                {
                    throw new ArgumentException("Nieprawidłowa wartość X koordynatu pierwszego punktu referencyjnego");
                }
                if (!double.TryParse(firstMapCoordinateY, out firstMapCoordinate.Y))
                {
                    throw new ArgumentException("Nieprawidłowa wartość Y koordynatu pierwszego punktu referencyjnego");
                }
                if (!int.TryParse(secondScreenCoordinateX, out secondScreenCoordinate.X))
                {
                    throw new ArgumentException("Nieprawidłowa wartość X koordynatu drugiego punktu referencyjnego");
                }
                if (!int.TryParse(secondScreenCoordinateY, out secondScreenCoordinate.Y))
                {
                    throw new ArgumentException("Nieprawidłowa wartość Y koordynatu drugiego punktu referencyjnego");
                }
                if (!double.TryParse(secondMapCoordinateX, out secondMapCoordinate.X))
                {
                    throw new ArgumentException("Nieprawidłowa wartość X koordynatu drugiego punktu referencyjnego");
                }
                if (!double.TryParse(secondMapCoordinateY, out secondMapCoordinate.Y))
                {
                    throw new ArgumentException("Nieprawidłowa wartość Y koordynatu drugiego punktu referencyjnego");
                }
                
                return new MapTransformationCoordinates()
                {
                    FirstMapCoordinate = firstMapCoordinate,
                    FirstScreenCoordinate = firstScreenCoordinate,
                    SecondMapCoordinate = secondMapCoordinate,
                    SecondScreenCoordinate = secondScreenCoordinate
                };
            }
        }
    }
}