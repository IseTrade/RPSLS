﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class HumanPlayer : Player
    {
        internal int score;

        //Custom implementation of ThrowGesture for HumanPlayer because Computer's gesture will be random. 
        public override string ThrowGesture()
        {
            //Capture the input from the Human Player
            string gesture = Console.ReadLine(); //Input required

            switch (gesture)
            {
                case "1":
                    Console.WriteLine("You've selected Rock");
                    return "1";
                case "2":
                    Console.WriteLine("You've selected Paper");
                    return "2";
                case "3":
                    Console.WriteLine("You've selected scissors");
                    return "3";
                case "4":
                    Console.WriteLine("You've selected Lizard");
                    return "4";
                case "5":
                    Console.WriteLine("You've selected Spock");
                    return "5";
                default:
                    Console.WriteLine("Please enter a valid number!!!");
                    return "0";
            }
        }

        internal void speakTaunt()
        {
            Console.WriteLine("PLAYER1 SAYS: YOU CHEATER! AIM BOT! HAKCER...");
        }
    }
}