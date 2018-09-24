﻿using System;
using System.Collections.Generic;

namespace RPSLS
{
    public class Game
    {
        List<string> gameOptionsList = new List<string>();
        HumanPlayer player1 = new HumanPlayer();
        HumanPlayer player2 = new HumanPlayer();
        ComputerPlayer computer = new ComputerPlayer();

        private static int p1choice = 0;
        private static int p2choice = 0;
        private int rounds = 1; //Round starts at 1

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Show Rules");
            Console.WriteLine("3. Quit Game");
            Console.WriteLine("");
            Console.Write("Enter an option to begin: ");
        }

        // Press Enter to continue
        public static void ShowGoBackMenu()
        {
            Console.WriteLine("Press Enter to return to the Main Screen");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                ShowMainMenu();
            }
            else
            {
                Console.ReadKey();
            }
        }

        //Submenu options for option 1
        public static void ShowSubMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose Mode:");
            Console.WriteLine("============");
            Console.WriteLine("");
            Console.WriteLine("1. 1P vs 2P");
            Console.WriteLine("2. 1P vs CPU");
            Console.WriteLine("3. Exit");
            Console.WriteLine("");
            Console.Write("Enter an option to begin: ");
        }

        //Present the choices to a specific player object
        public void ShowChoices(Player player)
        {
            Console.WriteLine("");
            //Reference the player object and call its methods
            Console.WriteLine(player.getName() + " Test Your Might! Round - " + rounds);
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
            ShowGoBackMenu();
        }

        //Build a list of game options which could have been fixed
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
            string mainMenuChoice = Console.ReadLine();

            //Check the user input and perform the action
            switch (mainMenuChoice)
            {
                case "1":
                    ShowSubMenu();
                    string subMenuChoice = Console.ReadLine();
                    switch (subMenuChoice)
                    {
                        case "1":
                            player1.setName("Player1");
                            player2.setName("Player2");
                            do
                            {
                                ShowChoices(player1);//Ask to choose an option
                                p1choice = Convert.ToInt32(player1.ThrowGesture());
                                ShowChoices(player2);//Ask to choose an option
                                p2choice = Convert.ToInt32(player2.ThrowGesture());
                                ComputeRoundScore(p1choice, p2choice);
                                rounds++;
                                ShowScores();
                            } while (rounds <= 5);
                            //ShowScores();
                            break;
                        case "2":
                            player1.setName("Player1");
                            player2.setName("Computer");
                            do
                            {
                                ShowChoices(player1);//Ask to choose an option
                                p1choice = Convert.ToInt32(player1.ThrowGesture());
                                p2choice = Convert.ToInt32(computer.ThrowGesture());//Computer does not ask for options
                                ComputeRoundScore(p1choice, p2choice);
                                rounds++;
                                ShowScores();
                            } while (rounds <= 5);
                            //ShowScores();
                            break;
                        case "3":
                        //Go through to default, no break required
                        default:
                            //Return to Main Menu
                            ShowMainMenu();
                            break;
                    }
                    break;
                case "2":
                    ShowGameRules();
                    ShowGoBackMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    ShowMainMenu();
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
                ShowChoices(player1);
                ShowChoices(player2);
            }
            else if ((beatsRock || beatsPaper || beatsScissors || beatsLizzard || beatsSpock) == true)
            {
                Console.WriteLine("PLAYER 1 WINS THE ROUND");
                player1.score += 1;
                ShowChoices(player1);
            }
            else
            {
                Console.WriteLine("COMPUTER WINS THE ROUND");
                player2.score += 1;
                ShowChoices(player2);
            }
        }

        public void ShowScores()
        {
            if (rounds >= 5)
            {
                if (player2.score > player1.score)
                {
                    if (player2.GetType() == typeof(HumanPlayer))
                    {
                        //HumanPlayer
                        Console.WriteLine("PLAYER 2 WINS THE GAME");
                        ShowNewGameMenu();
                    }
                    else
                    {
                        //ComputerPlayer
                        Console.WriteLine("COMPUTER WINS THE GAME");
                        ShowNewGameMenu();
                    }
                }
                else
                {
                    //HumanPlayer
                    Console.WriteLine("PLAYER 1 WINS THE GAME");
                    ShowNewGameMenu();
                }
            }
        }

        private static void ShowNewGameMenu()
        {
            Console.WriteLine("New Game? Y/N");
            string newGameChoice = Console.ReadLine();
            //Stackoverflow: If string equals string
            if (newGameChoice.ToLower().Equals("y"))
            {
                ShowMainMenu();
            }
        }
    }
}