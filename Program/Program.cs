namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //This wil take and see the arguments wrote by the user for
            //the simulation
            Properties properties = Properties.ReadArgs(args);
            //Creates the simulation with the arguments of the user
            Simulator simulation = new Simulator(properties);
            //Starts the simulation
            simulation.CoreLoop();
        }
    }
}
