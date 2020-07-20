using System;
using System.Collections.Generic;

namespace Program
{
    /// <summary>
    /// Defines an Agent in the simulation.
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// Static variable used to give each instance of Agent a unique ID
        /// </summary>
        private static int nextID = 0;

        /// <summary>
        /// Auto implemented property which gives a different ID to each
        /// instance of the class.
        /// </summary>
        /// <value></value>
        public int id {get;}
        
        /// <summary>
        /// Auto implemented property which indicates the health status of the
        /// Agent
        /// </summary>
        /// <value></value>
        public Status status {get; private set;}
        
        /// <summary>
        /// Auto implemented property which indicates the entity's position on 
        /// the world.
        /// </summary>
        /// <value></value>
        public Coord pos {get; set;}

        /// <summary>
        /// Variable which indicates the remaining lifetime in turns of the
        /// Agent
        /// </summary>
        private int lifetime;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="pos">The Agent's position</param>
        /// <param name="lifetime">Total lifetime of the Agent in turns.</param>
        public Agent(Coord pos, int lifetime)
        {
            this.id = nextID;
            nextID++;
            status = Status.Healthy;
            this.pos = pos;
            this.lifetime = lifetime;
        }

        /// <summary>
        /// Method that controls the random movement of the agent.
        /// </summary>
        /// <param name="world">Reference to the World object</param>
        /// <returns></returns>
        public Coord WhereToMove(World world)
        {
            // puts every possible direction in a list
            List<Direction> PossibleDirections = new List<Direction>();
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                PossibleDirections.Add(d);
            }

            // Picks a random direction 
            // until the picked direction is a valid move
            int rand = Simulator.random.Next(PossibleDirections.Count);
            Coord coord = world.GetNeighbour(pos, PossibleDirections[rand]);

            while (!(world.IsOnBoard(coord)))
            {
                rand = Simulator.random.Next(PossibleDirections.Count);
                coord = world.GetNeighbour(pos, PossibleDirections[rand]);
            }

            return coord;
        }


        /// <summary>
        /// Method responsible for lessening the lifetime of an infected agent, 
        /// and updating from infected to dead.
        /// </summary>
        /// <returns>The Agent's health status after the  change.</returns>
        public Status Damage()
        {
            if (status == Status.Infected)
            {
               lifetime--;
                if (lifetime == 0)
                    status = Status.Dead; 
            }
            return status;            
        }



    }
}