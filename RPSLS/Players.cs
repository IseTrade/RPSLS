using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Players
    {
        public void Gesture()
        {
            Console.WriteLine("Please enter your choice: ");
            Console.WriteLine("1.   Rock");
            Console.WriteLine("2.   Paper");
            Console.WriteLine("3.   Scissors");
            Console.WriteLine("4.   Lizard");
            Console.WriteLine("5.   Spock");
            //string choice1 = Console.ReadLine();
            string gesture = "1"; //test

            switch (gesture)
            {
                case "1":
                    Console.WriteLine("You've selected Rock");
                    //Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("You've selected Paper");
                    //Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("You've selected scissors");
                    //Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("You've selected Lizard");
                    //Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("You've selected Spock");
                    //Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number!!!");
                    //Console.ReadKey();
                    break;
            }
        }





    }
}
