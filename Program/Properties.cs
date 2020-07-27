using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace Program
{
    /// <summary>
    /// Struct responsible for reading the user input from command line, 
    /// and make them available as properties.
    /// </summary>
    public struct Properties
    {
        /// <summary>
        /// Auto-implemented property that contains one of the dimensions of 
        /// a NxN simulation grid.
        /// </summary>
        /// <value>One of the dimensions of a NxN simulation grid.</value>
        public int worldSize {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the initial number of 
        /// agents in the simulation.
        /// </summary>
        /// <value>Initial number of agents in the simulation.</value>
        public int totalAgents {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the total lifetime of an 
        /// agent after being infected, in turns.
        /// </summary>
        /// <value>Total lifetime of an agent after being infected, in turns.
        /// </value>
        public int agentLife {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the number of the turn 
        /// when the first, random, infection occurs.
        /// </summary>
        /// <value>Number of the turn when the first, random, infection occurs.
        /// </value>
        public int firstInfect {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the maximum limit of turns 
        /// allowed before the simulation ends.
        /// </summary>
        /// <value>Maximum limit of turns before the simulation ends.</value>
        public int maxTurns {get; private set;}
        /// <summary>
        /// Auto-implemented property that indicates whether the simulation 
        /// grid is shown on the console.
        /// </summary>
        /// <value><c>True</c> if simulation grid is shown on the console, 
        /// <c>false</c> otherwise</value>
        public bool viewSim {get; private set;}
        /// <summary>
        /// Auto-implemented property that indicates whether the simulation 
        /// stats are saved in an output file.
        /// </summary>
        /// <value><c>True</c> if simulation stats are save in a file, 
        /// <c>false</c> otherwise</value>
        public bool saveStats {get; private set;}
        /// <summary>
        /// Auto-implemented property that contains the name of the file where 
        /// the simulation stats are saved.
        /// </summary>
        /// <value></value>
        public string statsFile {get; private set;}

        /// <summary>
        /// Private constructor that initializes an instance of this struct
        /// with valid values for the different command line options.
        /// </summary>
        /// <param name="N">One dimension of the NxN grid.</param>
        /// <param name="M">Initial number of agents.</param>
        /// <param name="L">Lifetime of an agent after being infected.</param>
        /// <param name="Ti">Turn in which the first infection happens.</param>
        /// <param name="t">Maximum number of turns.</param>
        /// <param name="v">Whether the simulation grid should be shown or not.
        /// </param>
        /// <param name="o">Name of the output file to save the stats.</param>
        private Properties(int N, int M, int L, int Ti, int t, bool v, string o)
        {
            worldSize = N;
            totalAgents = M;
            agentLife = L+1;
            firstInfect = Ti;
            maxTurns = t;
            viewSim = v;
            saveStats = (o != null);
            statsFile = o;

        }

        /// <summary>
        /// Static method that parses the command line arguments and returns a 
        /// new <see cref="Properties"/> object which contains those same 
        /// arguments after being treated.
        /// </summary>
        /// <param name="args">Arguments from the command line.</param>
        /// <returns>An object of type <see cref="Properties"/> which contains 
        /// the simulation properties.</returns>
        public static Properties ReadArgs(string[] args)
        {
            // variables for the parameters passed 
            int N = 0, M = 0, L = 0, Tinf = 0, T = 0;
            int i = 1;
            string fileName = null;
            bool viewSimulation = false;

            string docpath = Directory.GetCurrentDirectory();

            // Check if there is enough arguments
            if (args.Length < 10)
            {
                Console.WriteLine("Please run with enough arguments");
                return new Properties();;
            }

            // Cycle to assign variables
            foreach(string s in args)
            {
                if (s == "-N" || s == "-n")
                    N = Convert.ToInt32(args[i]);
                else if (s == "-M" || s == "-m")
                    M = Convert.ToInt32(args[i]);
                else if (s == "-L" || s == "-l")
                    L = Convert.ToInt32(args[i]);
                else if (s == "-Tinf" || s == "-tinf")
                    Tinf = Convert.ToInt32(args[i]);
                else if (s == "-T" || s == "-t")
                    T = Convert.ToInt32(args[i]);
                else if (s == "-V" || s == "-v")
                    viewSimulation = true;
                else if (s == "-O" || s == "-o")
                    fileName = args[i];
                i++;
            }

            // Creates a file if it doesn´t exists
            FileStream file;
            if (fileName != null)
            {
                if(!File.Exists(docpath + "\\" + fileName))
                {
                    file = File.Create(docpath + "\\" + fileName);
                    file.Close();
                }
            }

            // Check if the variables aren´t 0
            if (N == 0 || M == 0 || L == 0 || T == 0 || Tinf == 0)
            {
                Console.WriteLine("Please run program whit at least -M, -N, " +
                    "-L, -T and -Tinf arguments (-v and -o are optional)");
                Console.WriteLine("Example: " + 
                    "dotnet run -- -N 50 -M 100 -L 10 -Tinf 5 -T 1000 -v -o" + 
                    " stats.tsv");
                return new Properties();
            }

            //returns all the proprieties of the user
            return new Properties(N, M, L, Tinf, T, viewSimulation, fileName);
        }
    }
}