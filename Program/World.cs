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

        public void Movement(int max_turn, int space)
        {
            int x;
            int y;

            foreach(KeyValuePair<Id, Coords> tile in dic)
            {
                Random rnd = new Random();

                while(true)
                {
                    x = rnd.Next(-1,1);
                    y = rnd.Next(-1,1);

                    if((x == 0) && (y == 0))
                    {
                    }
                    else
                    {
                        if(((tile.Value.X+x) < 0) || ((tile.Value.X+x) > space) 
                        || ((tile.Value.Y+y) < 0) || ((tile.Value.Y+y) > space))
                        {
                        }
                        else
                        {
                            dic[tile.Key] = 
                            new Coords(tile.Value.X + x, tile.Value.Y + y);
                            break;
                        }
                    }
                }
            }
        }
    }
}