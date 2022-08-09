using System;

namespace RPSGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            //What we need to run the game so we create an instance of the gameplay class 
            //Game.NewGame();
            // Game.NewPlayers();
            // Round.NewRound(); 
            GamePlay gamePlay = new GamePlay();
            gamePlay.RunGamePlay();
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