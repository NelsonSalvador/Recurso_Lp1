using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace Program
{
    public class Properties
    {
        public int worldSize {get; private set;}
        public int totalAgents {get; private set;}
        public int agentLife {get; private set;}
        public int firstInfect {get; private set;}
        public int maxTurns {get; private set;}
        public bool viewSim {get; private set;}
        public bool saveStats {get; private set;}
        public string statsFile {get; private set;}

        public Properties(int N, int M, int L, int Ti, int t, bool v, string o)
        {
            worldSize = N;
            totalAgents = M;
            agentLife = L;
            firstInfect = Ti;
            maxTurns = t;
            viewSim = v;
            saveStats = (o != null);
            statsFile = o;

        }

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
                return null;
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
                else if (s == "-O")
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
                return null;
            }

            return new Properties(N, M, L, Tinf, T, viewSimulation, fileName);
        }
    }
}