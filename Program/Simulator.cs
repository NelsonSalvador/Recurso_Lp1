using System;
using System.Collections.Generic;

namespace Program
{
    public class Simulator
    {
        private int currentTurn = 1;
        public World world;
        public Ui ui;
        public FileUpdate fileUpdate;
        private List<Agent> agentsHealthy;
        private List<Agent> agentsInfected;
        private List<Agent> agentsRecentDeath;
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
            agentsRecentDeath = new List<Agent>();
            agentsDead = new List<Agent>();
            ui = new Ui(agentsHealthy, agentsInfected, agentsDead, prop);

            if(prop.saveStats)
            {
                fileUpdate = new FileUpdate(
                    agentsHealthy, agentsInfected, agentsDead, prop.statsFile);
            }


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
        }

        /// <summary>
        /// This method infects all the agents at a given coordinate 
        /// <param name="c">.
        /// </summary>
        /// <param name="c">The coordinate to infect.</param>
        public void InfectPos(Coord c)
        {
            //for each agent in the same space as an infected agent, remove them
            //from the healthy list to put them in the infected list
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

                    agentsHealthy.Remove(a);
                    a.status = Status.Infected;
                    if(!agentsInfected.Contains(a))
                        agentsInfected.Add(a);
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

                ui.viewSim(currentTurn, agentsRecentDeath);

                //checks if there's the option of saving the date in a file
                if(prop.saveStats)
                {
                    //updates a list of the recent data
                    fileUpdate.updateData();
                }
                
                //Goes for the next turn
                currentTurn++;
            }

            //Since the simulation has ended, then all the date is written
            //in a file if the option of saving is on
            if(prop.saveStats)
            {
                fileUpdate.WriteOnFile();
            }
        }
        
    }
}