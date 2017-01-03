namespace MouseGet.Model
{
    public class MapCoordinate
    {
        public double X;
        public double Y;
        public double Z;

        public override string ToString()
        {
            return ("{" + Y + "," + X + "," + Z + "}");
        }
    }
}