namespace MouseGet.Model
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public decimal Z;

        public override string ToString()
        {
            return (X + "," + Y + "," + Z);
        }
    }
}
