namespace Program
{
    public struct Stats
    {
        public int healthy;
        public int infected;
        public int dead;

        public Stats(int h, int i, int d)
        {
            healthy = h;
            infected = i;
            dead = d;
        }

        public override string ToString()
        {
            return $"{healthy}\t{infected}\t{dead}\n";
        }
    }
}
