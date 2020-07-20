using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables for the parameters passed 
            int N = 0, M = 0, L = 0, Tinf = 0, T = 0;
            int i = 1;
            bool viewSimulation = false;

            // Check if there is enough arguments
            if (args.Length < 10)
            {
                Console.WriteLine("Please run with enough arguments");
                Environment.Exit(0);
            }

            // Cicle to assign variables
            foreach(string s in args)
            {
                if (s == "-N")
                    N = Convert.ToInt32(args[i]);
                else if (s == "-M")
                    M = Convert.ToInt32(args[i]);
                else if (s == "-L")
                    L = Convert.ToInt32(args[i]);
                else if (s == "-Tinf")
                    Tinf = Convert.ToInt32(args[i]);
                else if (s == "-T")
                    T = Convert.ToInt32(args[i]);
                else if (s == "-V")
                    viewSimulation = true;
                i++;
            }

            // Check if the variables aren´t 0
            if (N == 0 || M == 0 || L == 0 || T == 0 || Tinf == 0)
            {
                Console.WriteLine("Please run program whit at least -M, -N, " +
                    "-L, -T and -Tinf arguments (-v and -o are optional)");
                Console.WriteLine("Example: " + 
                    "dotnet run -- -N 50 -M 100 -L 10 -Tinf 5 -T 1000 -v -o" + 
                    " stats.tsv");
                Environment.Exit(0);
            }

            // Call the Simulator class and pass the variables 
            Simulator simulator = new Simulator(N, M, L, T, Tinf,
                viewSimulation);

        }
    }
}
