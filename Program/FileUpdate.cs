using System.Collections.Generic;
using System.IO;

namespace Program
{
    /// <summary>
    /// Class responsible for writing simulation info into text file
    /// </summary>
    public class FileUpdate
    {
        
        
        /// <summary>
        /// List fo healthy agents in the simulation.
        /// </summary>
        private List<Agent> agentsHealthy {get;}
        /// <summary>
        /// List of infected agents in th simulation
        /// </summary>
        private List<Agent> agentsInfected {get;}
        /// <summary>
        /// List of dead agents in th simulation
        /// </summary>
        private List<Agent> agentsDead {get;}
        /// <summary>
        /// String responsible for storing the name of the output file.
        /// </summary>

        private string fileName;
        /// <summary>
        /// List of strings responsible for storing the data from each turn.
        /// </summary>
        private List<string> dataSaver;
        /// <summary>
        /// Constructor. Receives lists of agents and output file name.
        /// </summary>
        /// <param name="healty">Reference to the list of healthy agents.
        /// </param>
        /// <param name="infected">Reference to the list of infected agents.
        /// </param>
        /// <param name="dead">Reference to the list of dead agents.
        /// </param>
        /// <param name="fileName">String containing the output file name.
        /// </param>
        public FileUpdate(List<Agent> healty, List<Agent> infected, 
            List<Agent> dead, string fileName)
        {
            this.agentsDead = dead;
            this.agentsHealthy = healty;
            this.agentsInfected = infected;
            this.fileName = fileName;
            dataSaver = new List<string>();
        }

        /// <summary>
        /// Method that updates the data list with data from the latest turn.
        /// </summary>
        public void updateData()
        {
            string line = $"{agentsHealthy.Count}\t{agentsInfected.Count}" +
            "\t{agentsDead.Count}";
            dataSaver.Add(line);
        }

        /// <summary>
        /// Method that creates or opens, and writes the data to an output file.
        /// </summary>
        public void WriteOnFile()
        {
            //gets the path to the file
            string docPath = Directory.GetCurrentDirectory();

            //write all the date of the list dataSaver to the file
            using (StreamWriter outputFile = 
                            new StreamWriter(Path.Combine(docPath, fileName)))
            {
                foreach(string a in dataSaver)
                {
                    outputFile.WriteLine(a);
                }
            }
        }

    }
}