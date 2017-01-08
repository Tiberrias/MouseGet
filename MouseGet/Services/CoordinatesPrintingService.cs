using System.Collections.Generic;
using System.Text;
using MouseGet.Model;
using MouseGet.Services.Interfaces;

namespace MouseGet.Services
{
    class CoordinatesPrintingService : ICoordinatesPrintingService
    {
        public string Print(List<MapCoordinate> mapCoordinates)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            foreach (var coordinate in mapCoordinates)
            {
                stringBuilder.Append(coordinate);
                stringBuilder.Append(",");
            }
            if (stringBuilder.Length > 1)
            {
                stringBuilder.Length = stringBuilder.Length - 1;
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

    }
}