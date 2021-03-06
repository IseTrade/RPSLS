﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class ComputerPlayer : Player
    {
        private string playerName;

        //An overloaded constructor which takes a string parameter
        public ComputerPlayer(string name)
        {
            SetName(name);
        }

        //Allow us to get the name
        public override string GetName()
        {
            return playerName;
        }

        //Allow us to set the name
        public override void SetName(string name)
        {
            playerName = name;
        }

        //Custom implementaton of the ThrowGesture for ComputerPlayer
        public override string ThrowGesture()
        {
            //Generate a random number and use that as the computer selection
            string gesture = GenerateRandomOption(); //No input required

            Console.WriteLine("");

            switch (gesture)
            {
                //Showing the output of the computer choice to prevent computer cheating
                case "1":
                    Console.WriteLine("Computer selected Rock");
                    return "1";
                case "2":
                    Console.WriteLine("Computer selected Paper");
                    return "2";
                case "3":
                    Console.WriteLine("Computer selected Scissors");
                    return "3";
                case "4":
                    Console.WriteLine("Computer selected Lizard");
                    return "4";
                case "5":
                    Console.WriteLine("Computer selected Spock");
                    return "5";
                default:
                    Console.WriteLine("Computer choice error!");
                    return "0";
            }
        }

        //A function to return a random number for the computer selection
        private string GenerateRandomOption()
        {
            Random randomGenerator = new Random();
            string randomChoice = randomGenerator.Next(1, 6).ToString(); //Options between 1 and up to but not including the last number
            return randomChoice;
        }
    }
}
