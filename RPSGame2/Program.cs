using System;

namespace RPSGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            //What we need to run the game so we create an instance of the gameplay class 
            GamePlay thisGame = new GamePlay();
            string user1 = "";
            //Start The Game
            thisGame.NewGame();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("\tCreate your username below:");
            try{
                user1 = thisGame.P1Name(Console.ReadLine());

            }catch (NullReferenceException msg){
                Console.WriteLine($"The string method to set the P1Name was thrown by this message: '{msg.Message}'.");
            }finally{
                user1 = "Player 1";
            }

            Console.WriteLine($"\tYour new username is:\n\t{user1}");
            
        }
    }
}

//REMEMBER TO VALIDATE USER INPUT
// try
// {
//     player1Choice = Int32.Parse(player1ChoiceStr);
// }
// catch (OverflowException ex)
// {
//     //this method to write to the console is string interpolation.
//     Console.WriteLine($"The parse method failed because '{ex.Message}'.");

// }
// catch (FormatException ex)
// {
//     Console.WriteLine($"The parse method failed because {ex.Message}");//this method to write to the console is string interpolation.
// }
// catch (ArgumentNullException ex)
// {
//     Console.WriteLine("The parse method failed because {0}", ex.Message);// This is Composite Formatting.
// }