using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        public void Engine()
        {
            Players player1 = new Players();
            // test1.Choice1();
            Players player2 = new Players();
            // test2.Choice2();

            int p1; int p2;
            bool b1; bool b2; bool b3; bool b4; bool b5;

            p1 = 4; //test overrides
            p2 = 2; //test overrides

            //boolean conditions must hold a boolean (mini inline if statement -- TERNARY OPERATOR)
            b1 = (p1 == 1 && (p2 == 3 || p2 == 4)); // ? true : false;
            b2 = (p1 == 2 && (p2 == 1 || p2 == 5)); // ? true : false;
            b3 = (p1 == 3 && (p2 == 2 || p2 == 4)); // ? true : false;
            b4 = (p1 == 4 && (p2 == 5 || p2 == 2)); // ? true : false;
            b5 = (p1 == 5 && (p2 == 3 || p2 == 1)); // ? true : false;

            if (p1 == p2)
            {
                Console.WriteLine("It's a draw.");
                Console.ReadKey();
            }
            else if ((b1 || b2 || b3 || b4 || b5) == true)
            {
                Console.WriteLine("Congrats player 1. YOU WIN!!!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Congrats player 2. YOU WIN!!!");
                Console.ReadKey();
            }
        }
    }
}
