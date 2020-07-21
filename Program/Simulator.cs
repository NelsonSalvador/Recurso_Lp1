using System;
using System.Threading;
using System.Collections.Generic;

namespace Program
{
    public class Simulator
    {
        private int currentTurn = 1;
        public World world;
        private List<Agent> agentsHealthy;
        private List<Agent> agentsInfected;
        private List<Agent> agentsRecentDeath;
        private List<Agent> agentsDead;
        public List<Stats> simStats;
        private Properties prop;
        public static Random random {get; private set;}


        /// <summary>
        /// Class constructor. Creates and places healthy agents on world.
        /// </summary>
        /// <param name="properties">Simulation properties</param>
        public Simulator(Properties properties)
        {
            // initializes instance variables
            this.prop = properties;
            world = new World(prop.worldSize, prop.totalAgents, prop.agentLife);
            random = new Random();
            agentsHealthy = new List<Agent>();
            agentsInfected = new List<Agent>();
            agentsRecentDeath = new List<Agent>();
            agentsDead = new List<Agent>();
            simStats = new List<Stats>();


            // creates and places healthy agents
            for (int i = 0; i < prop.totalAgents; i++)
            {
                int x = random.Next(prop.worldSize);
                int y = random.Next(prop.worldSize);
                Coord c = new Coord(x, y);

                Agent a = new Agent(c, prop.agentLife);

                agentsHealthy.Add(a);
                world.PlaceAgent(a, c);
            }


            /*Proprieties importantes para gameloop:
            agentes vivos,
            turnos,
            turno infetado.

            Proprieties importantes para UI:
            turnos,
            agentes (todos os estados)
            */
            //this.agents_alive = M;

            //GameLoop(view, T, Tinf, worldSize);
        }

        /// <summary>
        /// This method infects all the agents at a given coordinate 
        /// <param name="c">.
        /// </summary>
        /// <param name="c">The coordinate to infect.</param>
        public void InfectPos(Coord c)
        {
            foreach (Agent a in world.map[c])
            {
                agentsHealthy.Remove(a);
                a.status = Status.Infected;
                if(!agentsInfected.Contains(a))
                    agentsInfected.Add(a);
            }
        }

        public void CoreLoop()
        {
            // While under maximum turns, and still agents alive
            while(currentTurn <= prop.maxTurns 
                && agentsDead.Count < prop.totalAgents)
            {
                // clear recent death list
                agentsRecentDeath.Clear();

                // if turn = Tinf, randomly infect agent
                if(currentTurn == prop.firstInfect)
                {
                    int rand = random.Next(prop.totalAgents);
                    Agent a = agentsHealthy[rand];
                    InfectPos(a.pos);
                }

                // Move each healthy agent
                foreach(Agent a in agentsHealthy)
                {
                    Coord dest = a.WhereToMove(world);
                    world.MoveAgent(a, dest);
                }
                // move each infected agent, stores their position
                List<Coord> infPos = new List<Coord>();
                foreach(Agent a in agentsInfected)
                {
                    Coord dest = a.WhereToMove(world);
                    world.MoveAgent(a, dest);
                    infPos.Add(a.pos);
                }

                // for each pos with infected agent, infect all agents there
                foreach(Coord c in infPos)
                {
                    InfectPos(c);
                }

                // shorten life os infected agents and update lists
                for(int i = agentsInfected.Count - 1; i >= 0; i--)
                //foreach(Agent a in agentsInfected)
                {
                    Agent a = agentsInfected[i];
                    if(a.Damage() == Status.Dead)
                    {
                        // removes from infected
                        agentsInfected.RemoveAt(i);
                        world.map[a.pos].Remove(a);
                        // inserts at dead and recently dead
                        //if(!agentsRecentDeath.Contains(a))
                            agentsRecentDeath.Add(a);
                        //if(!agentsDead.Contains(a))
                            agentsDead.Add(a);
                    }
                }

                // removes recent death from infected
                // foreach (Agent a in agentsRecentDeath)
                // {
                //     agentsInfected.Remove(a);
                //     world.map[a.pos].Remove(a);
                // }

                
                // store stats for later use
                simStats.Add(new Stats(agentsHealthy.Count,
                                        agentsInfected.Count,
                                        agentsDead.Count));

                // show stats
                // TODO MOVE TO UI CLASS
                System.Console.WriteLine($"Turn {currentTurn} done" + 
                    $" ({agentsHealthy.Count} healthy, " + 
                    $" {agentsInfected.Count} infected, " + 
                    $" {agentsDead.Count} deceased)");

                // show sim world
                    // prints healthy spots
                    // prints infected spots
                    // prints recent deaths
                
                currentTurn++;
            }
        }

        //debug, deletar
        public void PrintAgentsData()
        {
            System.Console.Write("Healthy   ");
            foreach(Agent a in agentsHealthy)
                System.Console.Write(a.id + "  ");

            System.Console.WriteLine();
            System.Console.Write("Infected   ");
            foreach(Agent a in agentsInfected)
                System.Console.Write(a.id + "  ");

            System.Console.WriteLine();
            System.Console.Write("Dead   ");
            foreach(Agent a in agentsDead)
                System.Console.Write(a.id + "  ");
            System.Console.WriteLine();
        }

        
        // public void GameLoop(
        // bool view,int max_turn,int infection_turn ,int space)
        // {
        //     //FileWritter fileWriter = new FileWritter(...)
        //     world.Movement(max_turn, space);
        //     while(true)
        //     {
        //         if(/*(world.agents_alive == 0) && */(turn == max_turn))
        //         {
        //             //End the simulation, get the stats if the option is right
        //         }
        //         else
        //         {
        //             //world.World

        //             //fileWriter.AddToFile

        //             if(view)
        //             {
        //                 //UI ui = new UI(...)
        //                 Thread.Sleep(1000); 
        //             }
        //             else
        //             {
        //                 Thread.Sleep(400); 
        //             }
        //         }

        //     }
        // }
        
    }
}