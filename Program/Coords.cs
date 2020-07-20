namespace Program
{
    /// <summary>
    /// Stores all positions
    /// </summary>
    public struct Coords
    {
        public int X {get; set;}
        public int Y {get; set;}

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}