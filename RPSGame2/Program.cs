using System;
using System.Collections.Generic;

namespace RPSGame2
{
    class Program
    {
        public class Commands{
            
            public static string AskQuestion(){
                Console.WriteLine("What are we gonna do today?");
                string doToday = Console.ReadLine();
                return doToday;
            }

             
            

        }
        static void Main(string[] args)
        {            
            // Welcome message...
            Console.WriteLine("\t\tWelcome to you favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make its choice and you will be notified as to the winner.\n\nTo play, press enter.\n\n");

            // start the game by pressing ENTER
            //Console.ReadLine();

            // (unseen to the user) create some variables to store which choice the user made, 
            // computer choice, computer wins, user wins, number of ties, player1 name (user), player2 name (computer for now)

            int computerChoice = 0;
            Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.
            int player1Choice = -1;
            int player1wins = 0;//how many rounds p1 has won
            int computerWins = 0;//how many rounds the compouter has won
            int numberOfTies = 0;//how many ties there have been
            string player1Name = "";
            string computerName = "";
            string player1ChoiceStr;
            bool successfulConversion = false;
            bool isTie = true;
            string playAgain = "";

            // get the users name
            
            while(true){
                Console.WriteLine("What is your name?");
                player1Name = Console.ReadLine();
                if (player1Name.Length > 15){
                    Console.WriteLine("That name is too long.\n Please keep it within 15 characters.");
                    continue;
                }else{
                    Console.WriteLine($"Welcome to R-P-S Game, {player1Name}");
                    break;
                }
            }
            

            

            //this loop is for each beginning of a game.
            while (true)
            {


                //a while loop to keep prompting the user for choices till there isn't a tie.
                while ((isTie)|| (player1wins < 2) || (computerWins < 2))
                {
                    // get the users choice
                    Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
                    player1ChoiceStr = Console.ReadLine();

                    successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);
                    //Console.WriteLine($"the number you inputted was {successfulConversion}, {player1Choice}");


                    // get the computers random choice
                    computerChoice = (rand.Next(1000) % 3) + 1;
                    Console.WriteLine(computerChoice);

                    // evaluate the choices to determine the winner of the round.
                    // if it was a tie
                    if (player1Choice == computerChoice)
                    {
                        // tell them it was a tie and loop back up to the top to reprompt
                        Console.WriteLine($"This round was a tie!... Let's try again.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        numberOfTies++;// ++ increments the int by exactly 1.
                        //isTie = true;
                    }
                    // if the user won
                    else if ((player1Choice == 1 && computerChoice == 3) ||
                                (player1Choice == 2 && computerChoice == 1) ||
                                    (player1Choice == 3 && computerChoice == 2))
                    {
                        Console.WriteLine($"Congrats, {player1Name}, you won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1
                                                      // player1wins += 1;
                                                      // player1wins++;
                        isTie = false;
                    }
                    //if the computer won
                    else
                    {// if the computer won
                        Console.WriteLine($"I'm sorry, {computerName} won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        computerWins += 1;// this method gives you the option of incrementing by more than 1.
                        Console.WriteLine($"{player1Name}' score: {player1wins}\n Computer's score: {computerWins}");
                        isTie = false;
                    }
                }

                // ask if they want to play again. (if using rounds, each game would need to be stored.)
            Console.WriteLine($"Hey {player1Name}, would you like to play again?\n\tEnter'Y' to play again or 'N' to quit the program.");
            playAgain = Console.ReadLine();
            if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"The strings are equal");
                isTie = true;
            }
            else
            {
                //continue;// will end the current loop and immediately start the next iteration of the same loop.
                Console.WriteLine($"I'm sorry to see you go... se la vi.");
                break;
            }
            }


            // tell the user the tally results as of now.


            // Ask if they want to play again.(keep the tally live till the user wants to quit)



            //quit if they don't want to play... loop up to begin again if they DO want to play again.
            
            


            
        }
    }
}
