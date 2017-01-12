using System.Globalization;

namespace MouseGet.Model
{
    public class MapCoordinate
    {
        public double X;
        public double Y;
        public decimal Z;

        public override string ToString()
        {
            return ("{" + X.ToString(CultureInfo.InvariantCulture) + "," + Y.ToString(CultureInfo.InvariantCulture) + "," + Z.ToString(CultureInfo.InvariantCulture) + "}");
        }
    }
}