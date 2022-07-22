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
            //Welcome Message

            Console.WriteLine("Welcome to THE GAME!");
            Console.WriteLine("Lets play some Rock Paper Scissors.");

            //Instructors on how to play the game
            Console.WriteLine("Lets count how much your todo list is worth.");

            //start the game  by pressing enter

            //(Invisible to user)create user variables to store user choices
            int computerChoice = 0;
            int player1Choice = 0;
            int playerW1Wins = 0;
            int computerWins = 0;
            int numberOfFiles = 0;
            string player1Name = "";
            string computerName = "";
            //get the users choices

            // get the user name
            Console.WriteLine("What is your name?: ");

            player1Name = Console.ReadLine();

            Console.WriteLine($"Welcome {player1Name}");

            //evaluate the choices t 

            Console.WriteLine("Welcome to THE GAME!");
            Console.WriteLine("Lets count how much your todo list is worth.");
            Console.WriteLine("Type q to quit.");
            //int count = 0;
            //int rounds = 5;
            //A list to hold the input values
            List<string> answerList = new List<string>();
            string userAnswer = Commands.AskQuestion();
            while (userAnswer != "q"){
                //Add the answer to the list
                answerList.Add(userAnswer);
                //Ask the question
                userAnswer = Commands.AskQuestion();
                //Show the answer
                //Console.WriteLine(userAnswer);
                
                
                
            }
            //Print out the list 
            int totalResult = 0;    
            foreach (string i in answerList){
                //For every item in this list
                //Return the value of each list value

                Console.WriteLine($"Your Answers: {i.Length}");
                totalResult = totalResult + i.Length;
                

            }

            Console.WriteLine($"Your total Todo List Result is: {totalResult}");


            
        }
    }
}
