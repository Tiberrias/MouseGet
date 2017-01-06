using System.Globalization;

namespace MouseGet.Model
{
    public class MapCoordinate
    {
        public double X;
        public double Y;
        public double Z;

        public override string ToString()
        {
            return ("{" + Y.ToString(CultureInfo.InvariantCulture) + "," + X.ToString(CultureInfo.InvariantCulture) + "," + Z.ToString(CultureInfo.InvariantCulture) + "}");
        }
    }
}