using System;
using System.Collections.Generic;

namespace RPSLS
{
    public class Game
    {
        List<string> gameOptionsList = new List<string>();

        //Class methods
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("===============================================");
            Console.WriteLine("");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Quit Game");
            Console.WriteLine("");
            Console.Write("Select an option to begin: ");
        }

        public void ShowChoices()
        {
            Console.WriteLine("");
            Console.WriteLine("Test Your Might!");
            Console.WriteLine("");

            //Use two counters to loop through this list
            for (int i = 0, j = 1; i < gameOptionsList.Count; i++, j++)
            {
                //Print out the options in the form: #. - Options[i]
                Console.WriteLine(j + ". " + gameOptionsList[i]);
            }
            Console.WriteLine("");
            Console.Write("Enter a number: ");
        }

        public static void ShowGameRules()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The rules of the games are: ");
            Console.WriteLine("");
            Console.WriteLine("Rock crushes Scissors.");
            Console.WriteLine("Scissors cuts Paper.");
            Console.WriteLine("Paper covers Rock.");
            Console.WriteLine("Rock crushes Lizard.");
            Console.WriteLine("Lizard poisons Spock.");
            Console.WriteLine("Spock smashes Scissors.");
            Console.WriteLine("Scissors decapitates Lizard.");
            Console.WriteLine("Lizard eats Paper.");
            Console.WriteLine("Paper disproves Spock.");
            Console.WriteLine("Spock vaporizes Rock.");
            Console.WriteLine("");
            Console.WriteLine("Human player will choose a hand gesture and computer player will randomly choose a gesture");
            Console.WriteLine("5 rounds will be played and the player with the higher score wins.");
            Console.WriteLine("If hand gestures are the same for both players, it's a draw round.");
        }

        //Build a list of game options
        public void InitializeVariables()
        {
            gameOptionsList.Add("Rock");
            gameOptionsList.Add("Paper");
            gameOptionsList.Add("Scissors");
            gameOptionsList.Add("Lizzard");
            gameOptionsList.Add("Spock");
        }

        public void StartGame()
        {
            //Clear the list
            gameOptionsList.Clear();

            //1. Initialize variables
            InitializeVariables();

            ShowMainMenu();

            //2. Accept input from the user
            string gameChoice = Console.ReadLine();

            //3. Check the user input and perform the action
            if (gameChoice == "1")
            {
                HumanPlayer player1 = new HumanPlayer();
                ComputerPlayer player2 = new ComputerPlayer();

                ShowChoices();

                //Get player choices
                int p1choice = Convert.ToInt32(Console.ReadLine()); //Input required
                int p2choice = Convert.ToInt32(player2.ThrowGesture()); //No input required

                bool beatsRock;
                bool beatsPaper;
                bool beatsScissors;
                bool beatsLizzard;
                bool beatsSpock;

                //Game logic engine
                beatsRock = (p1choice == 1 && (p2choice == 3 || p2choice == 4));
                beatsPaper = (p1choice == 2 && (p2choice == 1 || p2choice == 5));
                beatsScissors = (p1choice == 3 && (p2choice == 2 || p2choice == 4));
                beatsLizzard = (p1choice == 4 && (p2choice == 5 || p2choice == 2));
                beatsSpock = (p1choice == 5 && (p2choice == 3 || p2choice == 1));

                Console.WriteLine("");

                //Game result output
                if (p1choice == p2choice)
                {
                    Console.WriteLine("DRAW!");
                }
                else if ((beatsRock || beatsPaper || beatsScissors || beatsLizzard || beatsSpock) == true)
                {
                    player1.score += 1;
                    Console.WriteLine("PLAYER 1 WINS THE ROUND");
                }
                else
                {
                    player2.score += 1;
                    Console.WriteLine("COMPUTER WINS THE ROUND");
                    player1.speakTaunt();
                    player2.speakTaunt();
                }
            }
            else
            {
                Console.Write("CONTINUE? Y/N");
                string rematchChoice = Console.ReadLine();
                if (rematchChoice == "Y" || rematchChoice == "y")
                {
                    //Restart the game options
                    ShowMainMenu();
                }
                else
                {
                    //Exit the game
                    System.Environment.Exit(0);
                }
            }

            //4. Score Tracking
            //TODO: A function to show both scores and show winner
            //ShowScores();
            //if (player1.score > player2.score) { Console.Write("PLAYER 1 WINS THE GAME"); } else { Console.Write("COMPUTER WINS THE GAME"); }

            //5. Next Round
            //TODO: A function to start another game?
            
        }
    }
}
