using System;
using System.Collections.Generic;

namespace Program
{
    public class World
    {
        private int worldSize;

        public Dictionary<Coord, List<Agent>> map {get; private set;}


        public World(int worldSize, int totalAgents, int agentLife)
        {
            this.worldSize = worldSize;
            
            map = new Dictionary<Coord, List<Agent>>();

            // creates empty dictionary
            for (int i = 0; i < worldSize; i++)
            {
                for(int j = 0; j < worldSize; j++)
                {
                    map.Add(new Coord(i, j), new List<Agent>());
                }
            }

        }

        /// <summary>
        /// Method that returns the list of agents at a given 
        /// coordinate <param name="c">.
        /// </summary>
        /// <param name="c">Position in the world.</param>
        /// <returns>list of agents at the position indicated in the paramenter
        /// <param name="c">.</returns>
        public List<Agent> GetAgentsAt(Coord c)
        {
            if (IsOnBoard(c))
                return map[c];
            return null;
        }

        /// <summary>
        /// Method that indicates if a given Coord <param name="c"> is inside 
        /// the limits of the world.
        /// </summary>
        /// <param name="c">A Position</param>
        /// <returns><c>true</c> if the Coord <param name="c"> is within the 
        /// limits of the board, <c>false</c> otherwise
        /// </returns>
        public bool IsOnBoard(Coord c)
        {
            if (c.x < 0)
                return false;
            if (c.y < 0)
                return false;
            if (c.x >= worldSize)
                return false;
            if (c.y > worldSize)
                return false;
            return true;

        }

        /// <summary>
        /// Method that returns the Neighbour position of the given position in
        /// the parameter <param name="coord">, in the direction of the 
        /// parameter <param name="direction">.
        /// </summary>
        /// <param name="coord">Position in the world</param>
        /// <param name="direction">Direction to check the Neighbour</param>
        /// <returns>Neighbour position of the given position in the paramenter
        /// <param name="coord"> in the direction of the paramenter
        /// <param name="direction">.
        /// </returns>
        public Coord GetNeighbour(Coord coord, Direction direction)
        {
            Coord neighbour = coord;

            switch(direction)
            {
                case Direction.N:
                    neighbour = coord - new Coord(0, 1);
                    break;
                case Direction.NE:
                    neighbour = coord - new Coord(-1, 1);
                    break;
                case Direction.E:
                    neighbour = coord - new Coord(-1, 0);
                    break;
                case Direction.SE:
                    neighbour = coord - new Coord(-1, -1);
                    break;
                case Direction.S:
                    neighbour = coord - new Coord(0, -1);
                    break;
                case Direction.SW:
                    neighbour = coord - new Coord(1, -1);
                    break;
                case Direction.W:
                    neighbour = coord - new Coord(1, 0);
                    break;
                case Direction.NW:
                    neighbour = coord - new Coord(1, 1);
                    break;
            }

            return neighbour;
        }

        /// <summary>
        /// Places agent <param name="entity"> in the position.
        /// </summary>
        /// <param name="agent">Agent to be placed.</param>
        /// <param name="coord">Position to place agent.</param>
        public void PlaceAgent(Agent agent, Coord coord)
        {
            map[coord].Add(agent);
        }

        /// <summary>
        /// Moves agent <param name="agent"> to the position 
        /// <param name="coord">
        /// </summary>
        /// <param name="agent">Agent to be moved</param>
        /// <param name="coord">Destination coordinate of the agent</param>
        public void MoveAgent(Agent agent, Coord coord)
        {
            map[coord].Add(agent);
            
            map[agent.pos].Remove(agent);

            agent.pos = coord;
        }

        

        // public void Movement(int max_turn, int space)
        // {
        //     int x;
        //     int y;

        //     foreach(KeyValuePair<Id, Coords> tile in dic)
        //     {
        //         Random rnd = new Random();

        //         while(true)
        //         {
        //             x = rnd.Next(-1,1);
        //             y = rnd.Next(-1,1);

        //             if((x == 0) && (y == 0))
        //             {
        //             }
        //             else
        //             {
        //                 if(((tile.Value.X+x) < 0) || ((tile.Value.X+x) > space) 
        //                 || ((tile.Value.Y+y) < 0) || ((tile.Value.Y+y) > space))
        //                 {
        //                 }
        //                 else
        //                 {
        //                     dic[tile.Key] = 
        //                     new Coords(tile.Value.X + x, tile.Value.Y + y);
        //                     break;
        //                 }
        //             }
        //         }
        //     }
        // }
    }
}