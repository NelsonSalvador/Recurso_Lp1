using System;
using System.Collections.Generic;

namespace Program
{
    public struct Id
    {
        public int identification {get;}
        public bool Infected {get;}

        public Id(int n, bool infected)
        {
            identification = n;
            Infected = infected;
        }

        public int[] Movement(int x, int y, int space)
        {
            int[] coords = new int[] {x, y};

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
                    if(((coords[0]+x) < 0) || ((coords[0]+x) > space) || 
                    ((coords[1]+y) < 0) || ((coords[1]+y) > space))
                    {
                    }
                    else
                    {
                        coords[0] += x;
                        coords[1] += y;
                        break;
                    }
                }

            }

            return coords;
        }
    }
}