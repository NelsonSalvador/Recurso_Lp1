namespace Program
{
    public struct Id
    {
        public int identification {get;}
        public bool Infected {get;}

        public Id(int n, bool infected)
        {
            identification = n;
            Infected = infected;
        }
    }
}