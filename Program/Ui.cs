using System;
using System.Threading;
using System.Collections.Generic;
namespace Program
{
    public class Ui
    {
        private List<Agent> agentsHealthy;
        private List<Agent> agentsInfected;
        private List<Agent> agentsDead;
        private Properties prop;
        public Ui(List<Agent> healty, List<Agent> infected, List<Agent> dead, Properties prop)
        {
            this.agentsDead = dead;
            this.agentsHealthy = healty;
            this.agentsInfected = infected;
            this.prop = prop;
        }

        public void viewSim(int currentTurn, List<Agent> recentDead)
        {
            bool empty = true;
            bool infected = false, healthy = false, dead = false;
            if (prop.viewSim == false)
            {
                Console.WriteLine($"Turn {currentTurn} done" + 
                    $" ({agentsHealthy.Count} healthy, " + 
                    $" {agentsInfected.Count} infected, " + 
                    $" {agentsDead.Count} deceased)");
            }
            else
            {
                Thread.Sleep(300);
                Console.WriteLine($"Turn {currentTurn} done" + 
                    $" ({agentsHealthy.Count} healthy, " + 
                    $" {agentsInfected.Count} infected, " + 
                    $" {agentsDead.Count} deceased)");
                Console.WriteLine("");
                for(int y = 0; y <= prop.worldSize; y++)
                {
                    for(int x = 0; x <= prop.worldSize; x++)
                    {   
                        foreach(Agent a in agentsHealthy)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                healthy = true;
                                empty = false;
                                break;
                            }
                        }
                        foreach(Agent a in agentsInfected)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                infected = true;
                                empty = false;
                                break;
                            }
                        }
                        foreach(Agent a in recentDead)
                        {
                            if(a.pos == new Coord(x, y))
                            {
                                dead = true;
                                empty = false;
                                break;
                            }
                        }

                        if (dead == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else if (infected == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else if (healthy == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
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