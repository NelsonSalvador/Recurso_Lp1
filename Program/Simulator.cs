using System;
using System.Threading;
using System.Collections.Generic;

namespace Program
{
    public class Simulator
    {
        //private int agents_alive;
        private int currentTurn = 0;
        public World world;
        private List<Agent> agentsHealthy;
        private List<Agent> agentsInfected;
        private List<Agent> agentsDead;
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
            agentsDead = new List<Agent>();


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
        public void infectPos(Coord c)
        {
            foreach (Agent a in world.map[c])
            {
                a.status = Status.Infected;
                agentsHealthy.Remove(a);
                agentsInfected.Add(a);
            }
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