using System;
using System.Collections.Generic;

namespace RPSLS
{
    public class Game
    {
        List<string> gameOptionsList = new List<string>();      
        HumanPlayer player1 = new HumanPlayer("Player 1");
        HumanPlayer player2 = new HumanPlayer("Player 2");
        ComputerPlayer computer = new ComputerPlayer("Computer");

        private static int p1choice;
        private static int p2choice;
        private int rounds = 1;
        private static string mainMenuChoice;

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.WriteLine("1. 1P vs 2P");
            Console.WriteLine("2. 1P vs Computer");
            Console.WriteLine("3. Game Rules");
            Console.WriteLine("4. Quit Game");
            Console.WriteLine("");
            Console.Write("Enter an option to begin: ");
        }

        //Present the choices to a specific player object
        public void ShowPlayerChoices(Player player)
        {
            //Reference the player object and call its methods
            Console.WriteLine(player.GetName() + " Test Your Might! Round - " + rounds);
            Console.WriteLine("");

            //Use two counters to loop through this list
            for (int i = 0, j = 1; i < gameOptionsList.Count; i++, j++)
            {
                //Print out the options in the form: #. - Options[i]
                Console.WriteLine(j + ". " + gameOptionsList[i]);
            }
            Console.WriteLine("");
            Console.Write("Enter an option number: ");
        }

        public static void ShowGameRules()
        {
            Console.Clear();
            Console.WriteLine("The Rock, Paper, Scissors, Lizard, Spock - Game Guide");
            Console.WriteLine("=====================================================");
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
            Console.WriteLine("You get five rounds to win the game against human or computer.");
            Console.WriteLine("The game is a draw if both choices match.");
            Console.WriteLine("");
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

        //Option 1
        public void StartGame()
        {
            //1. Initialize variables
            InitializeVariables();

            //2. Show Main Menu
            ShowMainMenu();
            mainMenuChoice = Console.ReadLine();

            //Check the user input and perform the action
            switch (mainMenuChoice)
            {
                case "1":
                    player1.score = 0;//reset
                    player2.score = 0;//reset
                    while (rounds < 6)
                    {
                        ShowPlayerChoices(player1);//Ask to choose an option
                        p1choice = Convert.ToInt32(player1.ThrowGesture());
                        ShowPlayerChoices(player2);//Ask to choose an option
                        p2choice = Convert.ToInt32(player2.ThrowGesture());
                        ComputeRoundScore(p1choice, p2choice);
                        rounds++;
                    }
                    ShowFinalScore();
                    break;
                case "2":
                    player1.score = 0;//reset
                    computer.score = 0;//reset
                    while (rounds < 6)
                    {
                        ShowPlayerChoices(player1);//Ask to choose an option
                        p1choice = Convert.ToInt32(player1.ThrowGesture());
                        p2choice = Convert.ToInt32(computer.ThrowGesture());//Computer does not ask for options
                        ComputeRoundScore(p1choice, p2choice);
                        rounds++;
                    }
                    //Show the final score
                    ShowFinalScore();
                    break;
                case "3":
                    ShowGameRules();
                    Console.ReadLine();
                    gameOptionsList.Clear();   //clearing the list so it wont add to itself
                    StartGame();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    //Return to Main Menu                    
                    Console.WriteLine("Please enter a valid input.");
                    Console.ReadLine();
                    gameOptionsList.Clear(); //clearing the list so it wont add to itself
                    StartGame();
                    break;
            }
        }

        //A function to compute the score given the two integer menu choices
         private void ComputeRoundScore(int p1choice, int p2choice)
        {
            bool beatsRock, beatsPaper, beatsScissors, beatsLizzard, beatsSpock;

            //Game engine logic
            beatsRock = (p1choice == 1 && (p2choice == 3 || p2choice == 4));
            beatsPaper = (p1choice == 2 && (p2choice == 1 || p2choice == 5));
            beatsScissors = (p1choice == 3 && (p2choice == 2 || p2choice == 4));
            beatsLizzard = (p1choice == 4 && (p2choice == 5 || p2choice == 2));
            beatsSpock = (p1choice == 5 && (p2choice == 3 || p2choice == 1));

            //Game result output
            Console.WriteLine("");
            if (p1choice == p2choice)
            {
                Console.WriteLine("DRAW!");
                rounds--; //Reduce the round to allow the do while loop to continue to occur
            }
            else if ((beatsRock || beatsPaper || beatsScissors || beatsLizzard || beatsSpock) == true)
            {
                Console.WriteLine("PLAYER 1 WINS");
                //Player 1 wins
                player1.score += 1;

            }
            else
            {
                Console.WriteLine("OPPONENT WINS!");
                player2.score += 1;
                computer.score += 1;
            }
        }

        public void ShowFinalScore()
        {
            //Print the final score in the form Player 1: 0 | Player 2: 0
            Console.Clear();
            Console.WriteLine("THE FINAL SCORE");
            Console.WriteLine("===============");
            Console.WriteLine("");
            if (mainMenuChoice == "1")
            {
                Console.WriteLine(player1.GetName() + ": {0} | " + player2.GetName() + ": {1}", player1.score, player2.score);
            }
            else
            {
                Console.WriteLine(player1.GetName() + ": {0} | " + computer.GetName() + ": {1}", player1.score, computer.score);
            }
            Console.WriteLine("");
            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }
    }
}