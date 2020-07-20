namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Properties properties = Properties.ReadArgs(args);
            Simulator simulation = new Simulator(properties);
        }
    }
}
