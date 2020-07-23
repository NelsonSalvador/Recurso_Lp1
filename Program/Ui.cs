using System;
using System.Threading;
using System.Collections.Generic;
namespace Program
{
    /// <summary>
    /// Class responsible for writing into the console.
    /// </summary>
    public class Ui
    {
        /// <summary>
        /// List of healthy agents.
        /// </summary>
        private List<Agent> agentsHealthy {get;}
        /// <summary>
        /// List of infected agents.
        /// </summary>
        private List<Agent> agentsInfected {get;}
        /// <summary>
        /// List of dead agents.
        /// </summary>
        private List<Agent> agentsDead {get;}
        /// <summary>
        /// Simulation properties.
        /// </summary>
        private Properties prop;
        /// <summary>
        /// Constructor. Receives lists of agents and simulation properties.
        /// </summary>
        /// <param name="healty">Reference to the list of healthy agents.
        /// </param>
        /// <param name="infected">Reference to the list of infected agents.
        /// </param>
        /// <param name="dead">Reference to the list of dead agents.
        /// </param>
        /// <param name="prop">Reference to the simulation's properties.
        /// </param>
        public Ui(List<Agent> healty, List<Agent> infected, List<Agent> dead, 
            Properties prop)
        {
            this.agentsDead = dead;
            this.agentsHealthy = healty;
            this.agentsInfected = infected;
            this.prop = prop;
        }

        /// <summary>
        /// Method responsible for writing info each turn on the console, and 
        /// showing the grid if necessary.
        /// </summary>
        /// <param name="currentTurn">Number of the current turn.</param>
        /// <param name="recentDead">List of agents who died on current turn.
        /// </param>
        public void viewSim(int currentTurn, List<Agent> recentDead)
        {
            bool empty = true;
            bool infected = false, healthy = false, dead = false;

            //the date of the simulation per turn
            Console.WriteLine($"Turn {currentTurn} done " + 
                $"({agentsHealthy.Count} healthy, " + 
                $"{agentsInfected.Count} infected, " + 
                $"{agentsDead.Count} deceased)");

            //if the user wants a visual representation of the simulation
            if (prop.viewSim == true)
            {
                //puts a little time between the turns to show up with all the
                //visual representation
                Thread.Sleep(300);
                //the board of the simulator itself per turn
                for(int y = 0; y <= prop.worldSize; y++)
                {
                    for(int x = 0; x <= prop.worldSize; x++)
                    {   
                        //look if there's a healthy agent in this placement
                        foreach(Agent a in agentsHealthy)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                healthy = true;
                                empty = false;
                                break;
                            }
                        }
                        //look if there's a infected agent in this placement
                        foreach(Agent a in agentsInfected)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                infected = true;
                                empty = false;
                                break;
                            }
                        }
                        //look if there's a recent dead agent in this placement
                        foreach(Agent a in recentDead)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                dead = true;
                                empty = false;
                                break;
                            }
                        }
                        //if there's a recent dead agent in this placement,
                        //the case will be colored red
                        if (dead == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        //if there's a infected agent in this placement,
                        //the case will be colored yellow
                        else if (infected == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        //if there's a healthy agent in this placement,
                        //the case will be colored green
                        else if (healthy == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        //if there's nothing special, then no color
                        else if (empty == true)
                        {
                            
                            Console.Write("  ");
                            
                        }
                        empty = true;
                        dead = false;
                        infected = false;
                        healthy = false;

                    }
                    Console.WriteLine("");
                }
                Console.WriteLine(" ");
            }
        }
        
    }
}