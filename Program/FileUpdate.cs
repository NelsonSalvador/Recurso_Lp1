using System.Collections.Generic;
using System.IO;

namespace Program
{
    public class FileUpdate
    {
        private List<Agent> agentsHealthy;
        private List<Agent> agentsInfected;
        private List<Agent> agentsDead;
        private string fileName;
        private List<string> dataSaver;
        public FileUpdate(List<Agent> healty, List<Agent> infected, 
            List<Agent> dead, string fileName)
        {
            this.agentsDead = dead;
            this.agentsHealthy = healty;
            this.agentsInfected = infected;
            this.fileName = fileName;
            dataSaver = new List<string>();
        }

        public void updateData()
        {
            string line = $"{agentsHealthy.Count}\t{agentsInfected.Count}\t{agentsDead.Count}";
            dataSaver.Add(line);
        }

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