using System.Threading;

namespace Program
{
    public class Simulator
    {
        private int agents_alive;
        private int turn = 0;
 
        public Simulator(int N, int M, int L, int T, int Tinf, bool view)
        {
            /*Proprieties importantes para gameloop:
            agentes vivos,
            turnos,
            turno infetado.

            Proprieties importantes para UI:
            turnos,
            agentes (todos os estados)
            */
            this.agents_alive = M;

            GameLoop(view, T, Tinf);
        }

        public void GameLoop(bool view, int max_turn, int infection_turn)
        {
            //World world = new World(N, M, L);
            //FileWritter fileWriter = new FileWritter(...)

            while(true)
            {
                if(/*(world.agents_alive == 0) && */(turn == max_turn))
                {
                    //End the simulation, get the stats if the option is right
                }
                else
                {
                    //world.World

                    //fileWriter.AddToFile

                    if(view)
                    {
                        //UI ui = new UI(...)
                        Thread.Sleep(1000); 
                    }
                    else
                    {
                        Thread.Sleep(400); 
                    }
                }

            }
        }
    }
}