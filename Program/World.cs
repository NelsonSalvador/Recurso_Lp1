using System;
using System.Collections.Generic;

namespace Program
{
    public class World
    {
        private Random random {get; set;}
        public Dictionary<Id, Coords> dic {get; set;}
        public World(int N, int M, int L)
        {
            random = new Random();
            int x, y;
            dic = new Dictionary<Id, Coords>();
            while (M != 0)
            {
                x = random.Next(N);
                y = random.Next(N);
                dic.Add(new Id(M, false), new Coords(x, y));
                M--;
            }
        }

        public void PrintGenerate()
        {
            foreach(KeyValuePair<Id, Coords> tile in dic)
            {
                Console.WriteLine(tile.Key.identification + " (" + tile.Value.X + ", " + tile.Value.Y + ") " + tile.Key.Infected);
            }
        }
    }
}